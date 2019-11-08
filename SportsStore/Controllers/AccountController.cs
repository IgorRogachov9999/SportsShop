using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Services;

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
            if (ModelState.IsValid && await accountService.Login(loginModel))
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
