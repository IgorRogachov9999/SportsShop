using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICategoryRepository categoryRepository;

        public NavigationMenuViewComponent( ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(categoryRepository.Categories);
        }

    }
}
