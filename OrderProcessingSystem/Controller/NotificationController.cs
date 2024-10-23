using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Service;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public NotificationController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("notify")]
        public IActionResult NotifyUser([FromBody] OrderRequest orderRequest)
        {
            _orderService.NotifyUser(orderRequest.ProductName);
            return Ok("Notificação enviada.");
        }
    }
}
