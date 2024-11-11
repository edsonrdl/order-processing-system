using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.NotificationDtos; // Usando o correto DTO para Notificação
using OrderProcessingSystem.Notificationservice;
using OrderProcessingSystem.UseCases.NotificationCreate;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationCreate _notificationCreate;

        public NotificationController(INotificationCreate notificationCreate)
        {
            this._notificationCreate = notificationCreate;
        }

        [HttpPost("notify")]
        public IActionResult NotifyUser([FromBody] NotificationRequest notificationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _notificationCreate.CreateNotification(notificationRequest);

            return Ok("Notificação enviada.");
        }
    }
}
