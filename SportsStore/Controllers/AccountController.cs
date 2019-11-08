using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewLayer.Services;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            string url = "";

            if (ModelState.IsValid)
            {
                url = await accountService.Login(loginModel);
            }

            if (url != "")
            {
                return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public RedirectResult Logout(string returnUrl = "/")
        {
            accountService.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}
