using BuisnessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Services;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ProductService ProductService;

        private CategoryService categoryService;

        public AdminController(ProductService ProductService, CategoryService categoryService)
        {
            this.ProductService = ProductService;
            this.categoryService = categoryService;
        }

        public ViewResult Index()
        {
            return View(ProductService.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(new EditProductViewModel
            {
                Product = ProductService.FindProduct(productId),
                AllCategories = categoryService.GetCategories()
            });
        }
           

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductService.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(new EditProductViewModel
                {
                    Product = product,
                    AllCategories = categoryService.GetCategories()
                });
            }
        }

        public ViewResult Create() => View("Edit", new EditProductViewModel {
            Product = new Product(),
            AllCategories = categoryService.GetCategories()
        });

        [HttpPost]  
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = ProductService.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}
