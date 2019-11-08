using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entityes;
using BuisnessLayer.Repositories;
using BuisnessLayer;
using DataLayer;

namespace DataLayer.EFRepositories
{
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext context;

        public EFProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> Products => context.Products.Where(p => p.IsEnable);

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID && p.IsEnable);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.ProductCategory = product.ProductCategory;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID && p.IsEnable);
            if (dbEntry != null)
            {
                dbEntry.IsEnable = false;
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Product FindProduct(int productId)
        {
            return Products.FirstOrDefault(p => p.ProductID == productId && p.IsEnable);
        }

        public IEnumerable<Product> CategoryProducts(string category)
        {
            return Products.Where(p => (category == null || p.ProductCategory == category) && p.IsEnable);
        }

        public IEnumerable<Product> GetProductPage(int page, int pageSize)
        {
            return Products
                    .OrderBy(p => p.IsEnable)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }
    }
}
