using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.ViewModels;

namespace ViewLayer.Services
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

        public async Task<string> Login(LoginModel loginModel)
        {
            IdentityUser user =
                await userManager.FindByNameAsync(loginModel.Name);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                {
                    return loginModel?.ReturnUrl ?? "/Admin/Index";
                }
            }

            return "";
        }

        public void SignOutAsync()
        {
            signInManager.SignOutAsync();
        }
    }
}
