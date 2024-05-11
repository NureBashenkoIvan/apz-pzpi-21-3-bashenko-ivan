using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmNomBox.API.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmNomBox.API.Presentation.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrderController(IServiceManager service) => _service = service;

        [HttpGet("admin")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetOrdersForAdmin([FromQuery] OrderParameters orderParameters)
        {
            var orders =
                await _service.OrderService.GetAllOrdersAsync(orderParameters, trackChanges: false);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
        {
            var userId = User.Claims.FirstOrDefault()?.Value;
            var orders =
                await _service.OrderService.GetAllOrdersForUserAsync(userId, orderParameters, trackChanges: false);
            return Ok(orders);
        }

        [HttpGet("{id:guid}", Name = "OrderById")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
            return Ok(order);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateUpdateOrderDto order)
        {
            
            var userId = User.Claims.FirstOrDefault()?.Value;
            var createdOrder = await _service.OrderService.CreateOrderAsync(userId, order);
            
            return CreatedAtRoute("OrderById", new { orderId = createdOrder.OrderId }, createdOrder);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _service.OrderService.DeleteOrderAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] CreateUpdateOrderDto order)
        {
            await _service.OrderService.UpdateOrderAsync(id, order, trackChanges: true);

            return NoContent();
        }
    }
}
