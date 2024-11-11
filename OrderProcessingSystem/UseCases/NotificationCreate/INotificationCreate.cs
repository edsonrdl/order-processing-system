using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Dtos.OrderDtos;

namespace OrderProcessingSystem.UseCases.NotificationCreate
{
    public interface INotificationCreate
    {
        void CreateNotification(NotificationRequest notificationRequest);
    }
}
