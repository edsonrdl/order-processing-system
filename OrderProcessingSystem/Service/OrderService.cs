using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public OrderService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void CreateOrder(string orderDetails)
        {
            _rabbitMqService.PublishMessage("order.new", orderDetails);
        }

        public void ProcessPayment(string paymentDetails)
        {
            _rabbitMqService.PublishMessage("order.payment", paymentDetails);
        }

        public void NotifyUser(string notificationDetails)
        {
            _rabbitMqService.PublishMessage("order.notification", notificationDetails);
        }
    }
}
