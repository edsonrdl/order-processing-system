using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.UseCases.NotificationCreate;

namespace OrderProcessingSystem.Mapper.NotificationMapper
{
    public class NotificationMapper : INotificationMapper
    {
        public  NotificationModel MapToNotificationModel(NotificationRequest request)
        {
            return new NotificationModel
            {
                NotificationId = Guid.NewGuid(),
                OrderId = request.OrderId,
                Message = request.Message,
                Status = request.Status,
                SentAt = DateTime.UtcNow
            };
        }

        public  NotificationResponse MapToNotificationResponse(NotificationRequest request)
        {
            return new NotificationResponse
            {
                OrderId = request.OrderId,
                Message = request.Message,
                //SentAt = model.SentAt,
                StatusDescription = request.Status.ToString()
            };
        }
    }
}
