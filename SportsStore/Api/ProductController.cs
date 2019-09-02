using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public int PageSize = 10;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{page}/{category?}")]
        public ProductsListViewModel Get(int page = 1, string category = null)
        {
            var products = _repository.Products
                    .Where(p => category == null || p.ProductCategory == category);

            int totalCount = products.Count();

            products = products
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = totalCount
            };

            return new ProductsListViewModel
            {
                Products = products,
                PagingInfo = pagingInfo,
                CurrentCategory = category
            };
        }
    }
}
