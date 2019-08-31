using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Models;
using SportsStore.Models.Repositories;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        private ICategoryRepository categoryRepository;

        public AdminController(IProductRepository repo, ICategoryRepository categoryRepository)
        {
            repository = repo;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(new EditProductViewModel
            {
                Product = repository.Products
                    .FirstOrDefault(p => p.ProductID == productId),
                AllCategories = categoryRepository.Categories
            });
        }
           

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(new EditProductViewModel
                {
                    Product = product,
                    AllCategories = categoryRepository.Categories
                });
            }
        }

        public ViewResult Create() => View("Edit", new EditProductViewModel {
            Product = new Product(),
            AllCategories = categoryRepository.Categories
        });

        [HttpPost]  
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}
