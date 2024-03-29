﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Repositories;
using BuisnessLayer.Entities;
using BuisnessLayer;
using DataLayer;

namespace DataLayer.EFRepositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private AppDbContext context;

        public EFOrderRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        public Order FindOrder(int orderID)
        {
            return context.Orders.Where(o => !o.Shipped)
                                 .Include(o => o.Lines)
                                 .ThenInclude(l => l.Product)
                                 .FirstOrDefault(o => o.OrderID == orderID);
        }

        public IEnumerable<Order> ActiveOrders => context.Orders
                                                         .Where(o => !o.Shipped)
                                                         .Include(o => o.Lines)
                                                         .ThenInclude(l => l.Product);

    }
}
