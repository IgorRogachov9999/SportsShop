using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categoriesItems = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            IEnumerable<string> categories;

            try
            {
                categories = categoriesItems.ToList();
            }
            catch (Exception ex)
            {
                categories = new LinkedList<string>();
            }

            return View(categories);
        }

    }
}
