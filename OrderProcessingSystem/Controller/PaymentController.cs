using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("payment")]
        public IActionResult PaymentOrder([FromBody] OrderRequest orderRequest)
        {
            this.paymentService.ProcessPayment(orderRequest.ProductName);
            return Ok($"O pagamento do produto {orderRequest.ProductName} foi processado com sucesso.");
        }
    }
}
