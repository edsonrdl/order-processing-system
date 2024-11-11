using OrderProcessingSystem.Dtos.NotificationDtos;

namespace OrderProcessingSystem.Notificationservice
{
    public interface INotificationService
    {
        void PublishOrderNotification(NotificationModel NotificationModel);
    }
}
