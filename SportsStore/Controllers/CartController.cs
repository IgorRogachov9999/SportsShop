using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ViewLayer.Services;
using ViewLayer.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private CartService cartService;

        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cartService.GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            cartService.PutProductToCart(productId);
            
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            cartService.DeleteProductFromCart(productId);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
    
