namespace OrderProcessingSystem.Dtos.NotificationDtos
{
    public class NotificationResponse
    {
        public Guid NotificationId { get; set; }
        public Guid OrderId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public string StatusDescription { get; set; }
    }
}
