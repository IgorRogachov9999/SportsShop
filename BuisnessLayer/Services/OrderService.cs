using BuisnessLayer.Repositories;
using BuisnessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuisnessLayer.Models;

namespace BuisnessLayer.Services
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

        public void MarkAsReaded(int orderID)
        {
            Order order = repository.FindOrder(orderID);

            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
        }

        public void Checkout(Order order)
        {
            order.Lines = Cart.Lines.ToArray();
            SaveOrder(order);
        }

        public void ClearCart()
        {
            Cart.Clear();
        }
    }
}
