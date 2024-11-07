using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public NotificationService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void SendNotification(NotificationModel notification)
        {
            // Ajuste usando as propriedades existentes em NotificationModel
            var notificationDetails = $"Order ID: {notification.OrderId}, Message: {notification.Message}, Sent At: {notification.SentAt}";
            _rabbitMqService.PublishMessage("order.notification", notificationDetails);
        }

    }
}
