using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entities;

namespace BuisnessLayer.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);

        Product FindProduct(int productId);

        IEnumerable<Product> CategoryProducts(string category);

        IEnumerable<Product> GetProductPage(int page, int pageSize, string category);
        
    }
}
