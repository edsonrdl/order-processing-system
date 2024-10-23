using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public PaymentController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("payment")]
        public IActionResult PaymentOrder([FromBody] OrderRequest orderRequest)
        {
            _orderService.ProcessPayment(orderRequest.ProductName);
            return Ok($"O pagamento do produto {orderRequest.ProductName} foi processado com sucesso.");
        }
    }
}
