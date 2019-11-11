using BuisnessLayer.Entityes;
using BuisnessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Tests.MockRepositories
{
    class MockProductReposiotory : IProductRepository
    {
        public LinkedList<Product> products;

        public MockProductReposiotory()
        {
            products = new LinkedList<Product>(); 
        }

        public void Clear()
        {
            products = new LinkedList<Product>();
        }

        public IEnumerable<Product> Products => products.Where(p => p.IsEnable);

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                int id = products.Last != null ? products.Last.Value.ProductID : 0;
                product.ProductID = id + 1;
                products.AddLast(product);
            }
            else
            {
                Product dbEntry = products
                    .FirstOrDefault(p => p.ProductID == product.ProductID && p.IsEnable);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.ProductCategory = product.ProductCategory;
                }
            }
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = products
                .FirstOrDefault(p => p.ProductID == productID && p.IsEnable);
            if (dbEntry != null)
            {
                dbEntry.IsEnable = false;
            }
            return dbEntry;
        }

        public Product FindProduct(int productId)
        {
            return products.FirstOrDefault(p => p.ProductID == productId && p.IsEnable);
        }

        public IEnumerable<Product> CategoryProducts(string category)
        {
            return products.Where(p => (category == null || p.ProductCategory == category) && p.IsEnable);
        }

        public IEnumerable<Product> GetProductPage(int page, int pageSize)
        {
            return products
                    .OrderBy(p => p.IsEnable)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }
    }
}
