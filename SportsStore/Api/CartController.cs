using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Repositories;
using ViewLayer.ViewModels;
using ViewLayer;
using ViewLayer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public ActionResult<Cart> GetCart() => cartService.GetCart();

        [HttpPut("{productId}")]
        public IActionResult PutProductToCart(int productId)
        {
            cartService.PutProductToCart(productId);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult<Cart> DeleteProductFromCart(int productId)
        {
            cartService.DeleteProductFromCart(productId);

            return GetCart();
        }
    }
}
