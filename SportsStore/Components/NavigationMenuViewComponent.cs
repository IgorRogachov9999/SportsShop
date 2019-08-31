using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Models;
using SportsStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        private ICategoryRepository categoryRepository;

        public NavigationMenuViewComponent(IProductRepository repo, ICategoryRepository categoryRepository)
        {
            repository = repo;
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            IEnumerable<Category> categories;

            try
            {
                categories = categoryRepository.Categories.ToList();
            }
            catch (Exception ex)
            {
                categories = new LinkedList<Category>();
            }

            return View(categories);
        }

    }
}
