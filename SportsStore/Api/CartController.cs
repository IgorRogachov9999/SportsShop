using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;

        private Cart cart;

        public CartController(IProductRepository repository, Cart cartService)
        {
            _repository = repository;
            cart = cartService;
        }

        [HttpGet]
        public ActionResult<Cart> GetCart() => cart;

        [HttpPut("{productId}")]
        public IActionResult PutProductToCart(int productId)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult<Cart> DeleteProductFromCart(int productId)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return cart;
        }
    }
}
