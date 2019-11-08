using BuisnessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class AccountService
    {
        private UserManager<IdentityUser> userManager;

        private SignInManager<IdentityUser> signInManager;

        public AccountService(UserManager<IdentityUser> userMgr,
            SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            IdentityUser user =
                await userManager.FindByNameAsync(loginModel.Name);

            if (user != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async void SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
