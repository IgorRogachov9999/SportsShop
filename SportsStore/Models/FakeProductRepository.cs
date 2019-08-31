using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product> {
            new Product { ProductID = 1, Name = "Football", Price = 25, Category = "Category 1" },
            new Product { ProductID = 2, Name = "Surf board", Price = 179, Category = "Category 2" },
            new Product { ProductID = 3, Name = "Running shoes", Price = 95, Category = "Category 3" }
        }.AsQueryable<Product>();

        public Product DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

