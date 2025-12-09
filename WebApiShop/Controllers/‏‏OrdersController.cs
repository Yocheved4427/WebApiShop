using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _ordersServices;
        public OrdersController(IOrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order? order = await _ordersServices.GetOrderById(id);
            if (order != null)
                return Ok(order);
            return NotFound();
        }

        [HttpPost]
       public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order newOrder = await _ordersServices.AddOrder(order);
            if (newOrder == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
        }






    }
}


