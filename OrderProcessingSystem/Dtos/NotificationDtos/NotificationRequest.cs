using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Dtos.NotificationDtos
{
    public class NotificationRequest
    {

        public Guid OrderId { get; set; }

        public string Message { get; set; }

        public NotificationStatusEnum Status { get; set; }
    }
}
