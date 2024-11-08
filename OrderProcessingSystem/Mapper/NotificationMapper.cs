using OrderProcessingSystem.Dtos.NotificationDtos;

namespace OrderProcessingSystem.Mapper
{
    public class NotificationMapper
    {
        public static NotificationRequest MapToNotificationModel(NotificationRequest request)
        {
            return new NotificationRequest
            {
                NotificationId = Guid.NewGuid(), 
                OrderId = request.OrderId,
                Message = request.Message,
                Status = request.Status,
                SentAt = DateTime.UtcNow 
            };
        }

        public static NotificationResponse MapToNotificationResponse(NotificationRequest model)
        {
            return new NotificationResponse
            {
                NotificationId = model.NotificationId,
                OrderId = model.OrderId,
                Message = model.Message,
                SentAt = model.SentAt,
                StatusDescription = model.Status.ToString()
            };
        }
    }
}
