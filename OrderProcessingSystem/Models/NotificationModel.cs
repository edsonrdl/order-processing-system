using System.ComponentModel.DataAnnotations;

public class NotificationModel
{
    public Guid NotificationId { get; set; }
    public Guid OrderId { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
