using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {
        private readonly IOrderRepository _repository;

        public CheckoutController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            Console.WriteLine("get..............................................");
            return _repository.Orders;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid || order.Lines.Count == 0)
            {
                return BadRequest(ModelState);
            }

            order.Lines = order.Lines.ToArray();
            order.OrderID = _repository.Orders.Last().OrderID + 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(order.OrderID);
            Console.ForegroundColor = ConsoleColor.Gray;
            // _repository.SaveOrder(order);
            return Ok();
        }

    }
}
