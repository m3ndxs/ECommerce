using ECommerce.Application.UseCases.Orders;
using ECommerce.Application.UseCases.Orders.Inputs;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Route("all")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderUseCase.GetAll());
        }

        [Authorize]
        [HttpGet]
        [Route("myorders")]
        public IActionResult GetMyOrders()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Usuário não autenticado.");

            int userId = int.Parse(userIdClaim);

            var orders = _orderUseCase.GetByUserId(userId);

            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrdersId(int id)
        {
            var order = _orderUseCase.GetId(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [Authorize(Roles = "Cliente")]
        [HttpPost]
        public IActionResult PostOrder([FromBody] AddOrderInput input)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var order = _orderUseCase.PostOrder(userId, input);

            return Ok(order);
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
