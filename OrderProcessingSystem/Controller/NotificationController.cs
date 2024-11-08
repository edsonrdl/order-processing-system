using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.NotificationDtos; // Usando o correto DTO para Notificação
using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("notify")]
        public IActionResult NotifyUser([FromBody] NotificationRequest notificationRequest)
        {
            // Valida os dados do request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Chama o serviço para enviar a notificação
            _notificationService.SendNotification(notificationRequest);

            return Ok("Notificação enviada.");
        }
    }
}
