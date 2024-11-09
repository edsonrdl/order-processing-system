using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("payment")]
        public IActionResult PaymentOrder([FromBody] PaymentRequest paymentRequest)
        {
            // Valida os dados do request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapeia a requisição para o modelo de domínio e processa o pagamento
            _paymentService.ProcessPayment(paymentRequest);

            return Ok($"O pagamento de {paymentRequest.Amount} para o pedido {paymentRequest.OrderId} foi processado com sucesso.");
        }
    }
}
