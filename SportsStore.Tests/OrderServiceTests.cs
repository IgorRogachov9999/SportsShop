using System;
using System.Collections.Generic;
using System.Text;
using BuisnessLayer.Entityes;
using BuisnessLayer.Models;
using BuisnessLayer.Services;
using SportsStore.Tests.MockRepositories;
using Xunit;
using System.Linq;

namespace SportsStore.Tests
{
    public class OrderServiceTests
    {
        private readonly MockOrderRepository repository;

        private readonly Cart cart;

        private OrderService orderService;

        public OrderServiceTests()
        {
            repository = new MockOrderRepository();
            cart = new Cart();
            orderService = new OrderService(repository, cart);
        }

        [Fact]
        public void Cart_Property_Should_Return_Cart()
        {
            Assert.Equal(orderService.Cart, cart);
        }

        [Fact]
        public void Checkout_Method_Should_Add_Order_To_Repository()
        {
            Order order = new Order()
            {
                Lines = null,
                Address = "Address",
                City = "City",
                Country = "Country",
                Name = "Name",
                OrderID = 0,
                Shipped = false
            };
            repository.Clear();

            orderService.Checkout(order);

            Assert.Equal(repository.orders.Count, 1);
            repository.Clear();
        }

        [Fact]
        public void Orders_Property_Should_Return_Orders()
        {
            Order order = new Order()
            {
                Lines = null,
                Address = "Address",
                City = "City",
                Country = "Country",
                Name = "Name",
                OrderID = 0,
                Shipped = false
            };
            orderService.Checkout(order);

            Assert.Equal(orderService.Orders, new List<Order>() { order } as IEnumerable<Order>);
            repository.Clear();
        }

        [Fact]
        public void FindOrder_Method_Should_Find_Order_In_Repository()
        {
            Order order = new Order()
            {
                Lines = null,
                Address = "Address",
                City = "City",
                Country = "Country",
                Name = "Name",
                OrderID = 0,
                Shipped = false
            };
            orderService.Checkout(order);

            Order orderFromService = orderService.FindOrder(order.OrderID);

            Assert.Equal(order, orderFromService);
            repository.Clear();
        }

        [Fact]
        public void SaveOrder_Method_Should_Save_Order_In_Repository()
        {
            Order order = new Order()
            {
                Lines = null,
                Address = "Address",
                City = "City",
                Country = "Country",
                Name = "Name",
                OrderID = 0,
                Shipped = false
            };
            orderService.SaveOrder(order);

            Assert.Equal(orderService.Orders, new List<Order>() { order } as IEnumerable<Order>);
            repository.Clear();
        }

        [Fact]
        public void MarkAsReaded_Method_Should_Set_Order_Shipped_True()
        {
            Order order = new Order()
            {
                Lines = null,
                Address = "Address",
                City = "City",
                Country = "Country",
                Name = "Name",
                OrderID = 0,
                Shipped = false
            };
            orderService.SaveOrder(order);
            orderService.MarkAsReaded(order.OrderID);

            Assert.True(repository.orders.First.Value.Shipped);
            repository.Clear();
        }

        [Fact]
        public void ClearCart_Method_Should_Clear_Cart()
        {
            int productId = -1;
            orderService.Cart.AddItem(new Product() { ProductID = productId }, 1);

            orderService.ClearCart();
            CartLine cartLine = orderService.Cart.Lines.FirstOrDefault(p => p.Product.ProductID == productId);

            Assert.Null(cartLine);
            repository.Clear();
        }
    }
}
