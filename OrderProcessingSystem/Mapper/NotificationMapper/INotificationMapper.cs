using OrderProcessingSystem.Dtos.NotificationDtos;

namespace OrderProcessingSystem.Mapper.NotificationMapper
{
    public interface INotificationMapper
    {
        NotificationModel MapToNotificationModel(NotificationRequest request);

        NotificationResponse MapToNotificationResponse(NotificationRequest response);
    }
}