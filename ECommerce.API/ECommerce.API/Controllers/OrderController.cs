using ECommerce.Application.UseCases.Orders;
using ECommerce.Application.UseCases.Orders.Inputs;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderUseCase _orderUseCase;

        public OrderController(IOrderUseCase orderUseCase)
        {
            _orderUseCase = orderUseCase;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderUseCase.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrdersId(int id)
        {
            var order = _orderUseCase.GetId(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult PostOrder(AddOrderInput input)
        {
            var order = _orderUseCase.PostOrder(input);

            return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
        }

        [HttpPut]
        [Route("{id:int}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] OrderStatus status)
        {
            return Ok(_orderUseCase.UpdateStatus(id, status));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok(_orderUseCase.DeleteOrder(id));
        }
    }
}
