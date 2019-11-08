using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuisnessLayer.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private ProductServcie productService;

        public ProductController(ProductServcie productService)
        {
            this.productService = productService;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            return View(productService.GetProductList(productPage, category));
        }
            
    }
}