using BuisnessLayer.Models;
using BuisnessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace SportsStore.Tests
{
    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public IdentityUser signedInUser;

        public FakeSignInManager(UserManager<IdentityUser> userManager)
                : base(userManager,
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object)
        { }

        public bool IsSignedIn(IdentityUser user)
        {
            return signedInUser != null && signedInUser.UserName == user.UserName;
        }

        public override async Task SignOutAsync()
        {
            signedInUser = null;
            await Task.Run(() => { });
        }

        public override async Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            await Task.Run(() => { });

            IdentityUser userFromManager = (UserManager as FakeUserManager).users.FirstOrDefault(u => u.UserName == user.UserName);
            bool result = userFromManager != null && userFromManager.PasswordHash == password;

            if (result)
            {
                signedInUser = user;
            }

            return new FakeSignInResult(result);
        }
    }

    public class FakeSignInResult : SignInResult {

        public FakeSignInResult(bool succeeded)
        {
            this.Succeeded = succeeded;
        }
    }

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public LinkedList<IdentityUser> users;

        public FakeUserManager()
            : base(new Mock<IUserStore<IdentityUser>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<IdentityUser>>().Object,
              new IUserValidator<IdentityUser>[0],
              new IPasswordValidator<IdentityUser>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        {
            users = new LinkedList<IdentityUser>();
        }

        public override async Task<IdentityUser> FindByNameAsync(string name) {
            return users.FirstOrDefault(u => u.UserName == name);
        }

        public override Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            users.AddLast(user);
            return base.CreateAsync(user, password);
        }
    }

    public class AccountServiceTests
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        private readonly AccountService service;

        private readonly IdentityUser user;

        private readonly string password;

        public AccountServiceTests()
        {
            userManager = new FakeUserManager();
            signInManager = new FakeSignInManager(userManager);
            service = new AccountService(userManager, signInManager);
            password = "password";
            user = new IdentityUser()
            {
                UserName = "Username",
                Email = "email@mail.com",
                PasswordHash = password
            };

            userManager.CreateAsync(user, password);
        }

        [Fact]
        public async Task Login_Method_Should_Return_True_On_Valid_User()
        {
            LoginModel loginModel = new LoginModel()
            {
                Name = user.UserName,
                Password = password,
                ReturnUrl = "/"
            };

            bool loginStatus = await service.Login(loginModel);

            bool isSignedIn = (signInManager as FakeSignInManager).IsSignedIn(user);

            Assert.True(loginStatus);
            Assert.True(isSignedIn);
        }

        [Fact]
        public async Task Login_Method_Should_Return_False_On_Invalid_Username()
        {
            string invalidString = "invalid";
            LoginModel loginModel = new LoginModel()
            {
                Name = user.UserName + invalidString,
                Password = password,
                ReturnUrl = "/"
            };

            bool loginStatus = await service.Login(loginModel);
            bool isSignedIn = (signInManager as FakeSignInManager).IsSignedIn(user);

            Assert.False(loginStatus);
            Assert.False(isSignedIn);
        }

        [Fact]
        public async Task Login_Method_Should_Return_False_On_Invalid_Password()
        {
            string invalidString = "invalid";
            LoginModel loginModel = new LoginModel()
            {
                Name = user.UserName,
                Password = password + invalidString,
                ReturnUrl = "/"
            };

            bool loginStatus = await service.Login(loginModel);
            bool isSignedIn = (signInManager as FakeSignInManager).IsSignedIn(user);

            Assert.False(loginStatus);
            Assert.False(isSignedIn);
        }

        [Fact]
        public async Task Login_Method_Should_Return_False_On_Invalid_User()
        {
            string invalidString = "invalid";
            LoginModel loginModel = new LoginModel()
            {
                Name = user.UserName + invalidString,
                Password = password + invalidString,
                ReturnUrl = "/"
            };

            bool loginStatus = await service.Login(loginModel);
            bool isSignedIn = (signInManager as FakeSignInManager).IsSignedIn(user);

            Assert.False(loginStatus);
            Assert.False(isSignedIn);
        }

        [Fact]
        public async Task SignOutAsync_Method_Should_Sign_Out_User()
        {
            LoginModel loginModel = new LoginModel()
            {
                Name = user.UserName,
                Password = password,
                ReturnUrl = "/"
            };

            await service.Login(loginModel);
            service.SignOutAsync();
            bool isSignedIn = (signInManager as FakeSignInManager).IsSignedIn(user);

            Assert.False(isSignedIn);
        }
    }
}
