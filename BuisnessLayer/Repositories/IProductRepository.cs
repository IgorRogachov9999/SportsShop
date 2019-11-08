﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entityes;

namespace BuisnessLayer.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);

        Product FindProduct(int productId);

        IEnumerable<Product> CategoryProducts(string category);

        IEnumerable<Product> GetProductPage(int page, int pageSize);
        
    }
}