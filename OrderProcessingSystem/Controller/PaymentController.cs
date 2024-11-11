using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.PaymentService;
using OrderProcessingSystem.UseCases.PaymentCreate;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentCreate _paymentCreate;

        public PaymentController(IPaymentCreate paymentCreate)
        {
            this._paymentCreate = paymentCreate;
        }

        [HttpPost("payment")]
        public IActionResult PaymentOrder([FromBody] PaymentRequest paymentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this._paymentCreate.CreatePayment(paymentRequest);

            return Ok($"O pagamento de {paymentRequest.Amount} para o pedido {paymentRequest.OrderId} está sendo  processado.");
        }
    }
}
