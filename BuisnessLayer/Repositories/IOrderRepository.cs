﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Entities;

namespace BuisnessLayer.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        void SaveOrder(Order order);

        IEnumerable<Order> ActiveOrders { get; }

        Order FindOrder(int orderID);

    }
}
