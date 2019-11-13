using BuisnessLayer.Repositories;
using BuisnessLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SportsStore.Tests.MockRepositories;
using System.Threading.Tasks;
using BuisnessLayer.Entities;
using System.Linq;
using BuisnessLayer.Models;

namespace SportsStore.Tests
{
    public class ProductServiceTests
    {
        private int PageSize = 10;

        private readonly MockProductReposiotory repository;

        private readonly ProductService service;

        public ProductServiceTests()
        {
            repository = new MockProductReposiotory();
            service = new ProductService(repository);
        }

        private LinkedList<Product> CreateProducts(int count)
        {
            LinkedList<Product> products = new LinkedList<Product>();

            for (int i = 0; i < count; i++)
            {
                products.AddLast(new Product()
                {
                    Description = $"Desctiption {i}",
                    Name = $"Name {i}",
                    IsEnable = true,
                    Price = 10 * i,
                    ProductID = 0,
                    ProductCategory = $"Category {i}"
                });
            }

            return products;
        }

        private void SaveProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                service.SaveProduct(product);
            }
        }
        
        [Fact]
        public void SaveProduct_MethodShould_Save_Products()
        {
            int productsCount = 10;
            LinkedList<Product> products = CreateProducts(productsCount);

            SaveProducts(products);

            Assert.Equal(products, repository.products);
            repository.Clear();
        }

        [Fact]
        public void Products_Property_Should_Returns_Products()
        {
            int productsCount = 10;
            IEnumerable<Product> products = CreateProducts(productsCount);
            SaveProducts(products);

            IEnumerable<Product> productsFromservice = service.Products;

            Assert.Equal(products, productsFromservice);
            repository.Clear();
        }

        [Fact]
        public void FindProduct_Should_Return_Product_By_Id()
        {
            int productCount = 10;
            int id = new Random().Next() % productCount + 1;
            LinkedList<Product> products = CreateProducts(productCount);
            SaveProducts(products);

            Product product = service.FindProduct(id);

            Assert.Equal(product.ProductID, id);
            repository.Clear();
        }

        [Fact]
        public void FindProduct_Should_Return_Null_By_Id()
        {
            int productCount = 10;
            int id = productCount + 1;
            LinkedList<Product> products = CreateProducts(productCount);
            SaveProducts(products);

            Product product = service.FindProduct(id);

            Assert.Null(product);
            repository.Clear();
        }

        [Fact]
        public void DeleteProduct_Method_Should_Delete_Product_And_Return_It()
        {
            int productCount = 10;
            int id = new Random().Next() % productCount + 1;
            LinkedList<Product> products = CreateProducts(productCount);
            SaveProducts(products);

            Product productBeforeDelete = repository.products.FirstOrDefault(p => p.ProductID == id && p.IsEnable);
            Product product = service.DeleteProduct(id);
            Product productAfterDelete = repository.products.FirstOrDefault(p => p.ProductID == id && p.IsEnable);

            Assert.NotNull(product);
            Assert.Equal(product.ProductID, productBeforeDelete.ProductID);
            Assert.Null(productAfterDelete);
            repository.Clear();
        }

        [Fact]
        public void DeleteProduct_Method_Should_Not_Delete_Product_And_Return_Null_On_Not_Used_Id()
        {
            int productCount = 10;
            int id = productCount + 1;
            LinkedList<Product> products = CreateProducts(productCount);
            SaveProducts(products);

            Product product = service.DeleteProduct(id);

            Assert.Null(product);
            repository.Clear();
        }

        [Fact]
        public void GetProductList_ShouldReturn_Products_List_Category_And_PagingInfo()
        {
            int productCount = 10;
            int page = 1;
            int id = new Random().Next() % productCount + 1;
            LinkedList<Product> products = CreateProducts(productCount);
            SaveProducts(products);
            string category = products.FirstOrDefault(p => p.ProductID == id).ProductCategory;
            IEnumerable<Product> productsInCategory = products.Where(p => p.ProductCategory == category);
            service.PageSize = PageSize;
            IEnumerable<Product> productsFromMock = repository.GetProductPage(page, PageSize);

            ProductsListViewModel productList = service.GetProductList(page, category);

            Assert.Equal(productList.CurrentCategory, category);
            Assert.Equal(productList.PagingInfo.CurrentPage, page);
            Assert.Equal(productList.Products, productsFromMock);
        }
    }
}
