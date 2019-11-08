using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using BuisnessLayer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryService.Categories;
        }
    }
}
