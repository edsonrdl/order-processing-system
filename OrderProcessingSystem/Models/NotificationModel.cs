namespace OrderProcessingSystem.Models
{
    public class NotificationModel
    {
        public Guid NoficationId { get; set; }
        public Guid OrderId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
