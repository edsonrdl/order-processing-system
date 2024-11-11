using OrderProcessingSystem.Models;
using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Enum;
using OrderProcessingSystem.RabbitMqService;
using OrderProcessingSystem.Mapper.NotificationMapper;

namespace OrderProcessingSystem.Notificationservice
{
    public class NotificationService : INotificationService
    {
        private readonly IRabbitMqService _rabbitMqService;


        public NotificationService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void PublishOrderNotification(NotificationModel notificationModel)
        {

            NotificationModel notification = GenerateNotificationMessage(notificationModel);

            string exchangeName = "service_exchange";

            string queue = "notification_queue";

            string routingKey = "order.notification";

            _rabbitMqService.PublishMessage(exchangeName,queue, routingKey, notification);
        }

        private NotificationModel GenerateNotificationMessage(NotificationModel notification)
        {
            notification.Message = notification.Status switch
            {
                NotificationStatusEnum.Pending => notification.Message="Pagamento pendente para o pedido.",
                NotificationStatusEnum.Completed => notification.Message = "Pagamento concluído com sucesso.",
                NotificationStatusEnum.Processing => notification.Message = "Pagamento sendo processado!.",
                NotificationStatusEnum.Cancelled => notification.Message = "Pedido cancelado.",
                _ => notification.Message = "Status de notificação desconhecido."
            };
            return notification;
        }
    }
}
