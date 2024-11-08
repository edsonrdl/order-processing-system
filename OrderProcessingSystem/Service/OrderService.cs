using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public OrderService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public  void CreateOrder(OrderModel orderModel)
        {
            _rabbitMqService.PublishMessage("order.new", orderModel);
        }
    }
}
