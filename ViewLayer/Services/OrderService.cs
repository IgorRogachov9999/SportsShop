using BuisnessLayer.Repositories;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewLayer.ViewModels;

namespace ViewLayer.Services
{
    public class OrderService
    {
        private IOrderRepository repository;

        private Cart cart;

        public OrderService(IOrderRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public Cart Cart => cart;

        public IEnumerable<Order> Orders => repository.ActiveOrders;

        public Order FindOrder(int orderID)
        {
            return repository.FindOrder(orderID);
        }

        public void SaveOrder(Order order)
        {
            repository.SaveOrder(order);
        }
    }
}
