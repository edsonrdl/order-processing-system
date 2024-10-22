using Microsoft.AspNetCore.Mvc;

namespace OrderProcessingSystem.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class Webhook:ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderRequest orderRequest)
        {
            _orderService.CreateOrder(orderRequest.Details);
            return Ok("Pedido enviado para criação.");
        }

        [HttpPost("payment")]
        public IActionResult PaymentOrder([FromBody] OrderRequest orderRequest)
        {
            _orderService.ProcessPayment(orderRequest.Details);
            return Ok("Detalhes de pagamento enviados.");
        }

        [HttpPost("notify")]
        public IActionResult NotifyUser([FromBody] OrderRequest orderRequest)
        {
            _orderService.NotifyUser(orderRequest.Details);
            return Ok("Notificação enviada.");
        }

        [HttpPost("webhook")]
        public IActionResult WebhookCallback([FromBody] string callbackData)
        {
            // Processar os dados recebidos do webhook
            return Ok("Webhook recebido e processado.");
        }
    }
}
