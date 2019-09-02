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
            return _repository.Orders;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Order");
            Console.WriteLine(order.ToString());
            Console.WriteLine("Order");
            Console.ForegroundColor = ConsoleColor.Gray;

            return NoContent();
        }

    }
}
