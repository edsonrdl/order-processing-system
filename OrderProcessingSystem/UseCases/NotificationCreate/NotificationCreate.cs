using Microsoft.AspNetCore.Razor.Hosting;
using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Mapper.NotificationMapper;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Notificationservice;

namespace OrderProcessingSystem.UseCases.NotificationCreate
{
    public class NotificationCreate : INotificationCreate
    {
        readonly INotificationMapper _notificationMapper;

        readonly INotificationService   _notificationService;
        public NotificationCreate(INotificationMapper notificationMapper  ,INotificationService notificationService)
        {
            this._notificationMapper = notificationMapper;
            this._notificationService = notificationService;
        }

        void INotificationCreate.CreateNotification(NotificationRequest notificationRequest)
        {
            try
            {
                NotificationModel notificationModel = this._notificationMapper.MapToNotificationModel(notificationRequest);
                Console.WriteLine(notificationModel);
                _notificationService.PublishOrderNotification(notificationModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");

                throw new ApplicationException("Ocorreu um erro inesperado ao criar a notificação !", ex);            }
        }
    }
}
