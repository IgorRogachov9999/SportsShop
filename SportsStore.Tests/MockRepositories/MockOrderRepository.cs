using BuisnessLayer.Entityes;
using BuisnessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Tests.MockRepositories
{
    class MockOrderRepository : IOrderRepository
    {
        public LinkedList<Order> orders;

        public MockOrderRepository()
        {
            orders = new LinkedList<Order>();
        }

        public void Clear()
        {
            orders = new LinkedList<Order>();
        }

        public IEnumerable<Order> Orders => orders.AsQueryable();

        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                order.OrderID = orders.Last != null ? orders.Last.Value.OrderID + 1 : 1;
                orders.AddLast(order);
            }
        }

        public Order FindOrder(int orderID)
        {
            return ActiveOrders.FirstOrDefault(o => o.OrderID == orderID);
        }

        public IEnumerable<Order> ActiveOrders => Orders.Where(o => !o.Shipped);
    }
}
