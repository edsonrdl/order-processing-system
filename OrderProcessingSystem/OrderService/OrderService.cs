using OrderProcessingSystem.Models;
using OrderProcessingSystem.RabbitMqService;

namespace OrderProcessingSystem.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public OrderService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void PublishOrder(OrderModel orderModel)
        {
            
            string exchangeName = "service_exchange";

            
            string routingKey = "order.new";


            _rabbitMqService.PublishMessage(exchangeName, routingKey, orderModel);
        }

    }
}
