﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entityes;

namespace BuisnessLayer.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);

        IEnumerable<Order> ActiveOrders { get; }

        Order FindOrder(int orderID);

    }
}