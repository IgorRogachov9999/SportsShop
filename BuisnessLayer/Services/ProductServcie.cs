using BuisnessLayer.Repositories;
using BuisnessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuisnessLayer.Models;

namespace BuisnessLayer.Services
{
    public class ProductService
    {
        public int PageSize = 10;

        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Product> Products => repository.Products;

        public Product FindProduct(int productId)
        {
            return repository.FindProduct(productId);
        }

        public void SaveProduct(Product product)
        {
            repository.SaveProduct(product);
        }

        public Product DeleteProduct(int productId)
        {
            return repository.DeleteProduct(productId);
        }

        public PageViewModel<Product> GetProductList(int page, string category)
        {
            var products = repository.CategoryProducts(category);

            int totalCount = products.Count();

            products = repository.GetProductPage(page, PageSize, category);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = totalCount
            };

            return new PageViewModel<Product>
            {
                PageData = products,
                PagingInfo = pagingInfo
            };
        }
    }
}
