using System;
using System.Collections.Generic;
using System.Text;
using BuisnessLayer.Repositories;

namespace BuisnessLayer
{
    public class DataManager
    {
        private ICategoryRepository categoryRepository;

        private IOrderRepository orderRepository;

        private IProductRepository productRepository;

        public DataManager(ICategoryRepository categoryRepository, 
                           IOrderRepository orderRepository, 
                           IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }
    }
}
