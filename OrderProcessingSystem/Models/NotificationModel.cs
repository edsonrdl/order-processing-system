using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

public class NotificationModel
{
    public Guid NotificationId { get; set; }

    [Required(ErrorMessage = "O código  do produto é obrigatório.")]
    public Guid OrderId { get; set; }

    [Required(ErrorMessage ="Mensagem do estado da compra deve ser informado!")]
    public string Message { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "O status da notificação é obrigatório.")]
    public NotificationStatusEnum Status { get; set; }
}
