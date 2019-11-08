using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using ViewLayer.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        public ViewResult List() =>
            View(orderService.Orders);

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = orderService.FindOrder(orderID);

            if (order != null)
            {
                order.Shipped = true;
                orderService.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (orderService.Cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = orderService.Cart.Lines.ToArray();
                orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            orderService.Cart.Clear();
            return View();
        }

    }
}
