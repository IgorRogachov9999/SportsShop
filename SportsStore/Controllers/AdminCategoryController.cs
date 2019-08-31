using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Models;
using SportsStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class AdminCategoryController : Controller
    {
        private ICategoryRepository repository;

        public AdminCategoryController(ICategoryRepository categoryRepository)
        {
            this.repository = categoryRepository;
        }

        public ViewResult Index()
        {
            return View(repository.Categories);
        }

        public IActionResult Edit(int categoryID)
        {
            Category category = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryID);

            if (category != null)
            {
                return View(category);
            } else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category dbCategory = repository.Categories.FirstOrDefault(c => c.Name == category.Name);
            bool isUniq = dbCategory == null || dbCategory.CategoryID == category.CategoryID;

            if (ModelState.IsValid && isUniq)
            {
                repository.SaveCategory(category);
                TempData["message"] = $"{category.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ViewResult Create() => View("Edit", new Category());

        [HttpPost]
        public IActionResult Delete(int categoryID)
        {
            Category deletedCategory = repository.DelteCategory(categoryID);
            if (deletedCategory != null)
            {
                TempData["message"] = $"{deletedCategory.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
