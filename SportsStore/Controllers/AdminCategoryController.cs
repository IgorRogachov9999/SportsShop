using Microsoft.AspNetCore.Mvc;
using ViewLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        private CategoryService categoryService;

        public AdminCategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ViewResult Index()
        {
            return View(categoryService.GetCategories());
        }

        public IActionResult Edit(int categoryID)
        {
            Category category = categoryService.FindCategory(categoryID);

            if (category != null)
            {
                return View(category);
            } 
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category dbCategory = categoryService.FindCategoryByName(category.Name);
            bool isUniq = dbCategory == null || dbCategory.CategoryID == category.CategoryID;

            if (ModelState.IsValid && isUniq)
            {
                categoryService.SaveCategory(category);
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
            Category deletedCategory = categoryService.DeleteCategory(categoryID);
            if (deletedCategory != null)
            {
                TempData["message"] = $"{deletedCategory.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
