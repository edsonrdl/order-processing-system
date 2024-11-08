using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Enum;
using OrderProcessingSystem.Mapper;

namespace OrderProcessingSystem.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public NotificationService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void SendNotification(NotificationRequest notificationRequest)
        {
            // Mapear o request para o modelo
            var notificationModel = NotificationMapper.MapToNotificationModel(notificationRequest);

            // Gera a mensagem a ser enviada
            string notificationDetails = GenerateNotificationMessage(notificationModel);

            // Publica a mensagem usando RabbitMQ
            _rabbitMqService.PublishMessage("order.notification", notificationDetails);
        }

        private string GenerateNotificationMessage(NotificationRequest notification)
        {
            string statusMessage = notification.Status switch
            {
                NotificationStatusEnum.PendingPayment => "Pagamento pendente para o pedido.",
                NotificationStatusEnum.PaymentCompleted => "Pagamento concluído com sucesso.",
                NotificationStatusEnum.OrderShipped => "Pedido enviado.",
                NotificationStatusEnum.OrderDelivered => "Pedido entregue.",
                NotificationStatusEnum.OrderCancelled => "Pedido cancelado.",
                _ => "Status de notificação desconhecido."
            };

            return $"Order ID: {notification.OrderId}, Status: {statusMessage}, Message: {notification.Message}, Sent At: {notification.SentAt}";
        }
    }
}
