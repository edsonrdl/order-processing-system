using OrderProcessingSystem.Dtos.NotificationDtos;

namespace OrderProcessingSystem.Interfaces
{
    public interface INotificationService
    {
        void SendNotification(NotificationRequest notification);
    }
}
