using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Dtos.NotificationDtos
{
    public class NotificationRequest
    {
        [Required(ErrorMessage = "O código do produto é obrigatório.")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Mensagem do estado da compra deve ser informada!")]
        public string Message { get; set; }

        [Required(ErrorMessage = "O status da notificação é obrigatório.")]
        public NotificationStatusEnum Status { get; set; }
    }
}
