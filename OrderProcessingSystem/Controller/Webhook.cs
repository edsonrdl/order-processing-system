using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        [HttpPost("webhook")]
        public IActionResult WebhookCallback([FromBody] string callbackData)
        {
            // Processar os dados recebidos do webhook (ex: atualizar status de pagamento)
            // Simulação: Atualizar status no banco de dados
            Console.WriteLine($"Webhook recebido: {callbackData}");
            return Ok("Webhook processado.");
        }
    }
}
