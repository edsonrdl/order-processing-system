using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Service;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) // Altere aqui para IOrderService
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderRequest orderRequest)
        {
            _orderService.CreateOrder(orderRequest.ProductName);
            return Ok("Pedido enviado para criação.");
        }
    }
}
