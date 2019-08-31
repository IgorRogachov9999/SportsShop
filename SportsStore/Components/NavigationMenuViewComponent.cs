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
            return View(categoryRepository.Categories);
        }

    }
}
