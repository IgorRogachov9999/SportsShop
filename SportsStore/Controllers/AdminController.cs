using BuisnessLayer.Entityes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Services;
using BuisnessLayer.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ProductServcie productServcie;

        private CategoryService categoryService;

        public AdminController(ProductServcie productServcie, CategoryService categoryService)
        {
            this.productServcie = productServcie;
            this.categoryService = categoryService;
        }

        public ViewResult Index()
        {
            return View(productServcie.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(new EditProductViewModel
            {
                Product = productServcie.FindProduct(productId),
                AllCategories = categoryService.GetCategories()
            });
        }
           

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productServcie.SaveProduct(product);
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
            Product deletedProduct = productServcie.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}
