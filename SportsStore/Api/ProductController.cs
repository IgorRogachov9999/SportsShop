using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Services;
using BuisnessLayer.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{page}/{category?}")]
        public ProductsListViewModel Get(int page = 1, string category = null)
        {
            return productService.GetProductList(page, category);
        }
    }
}
