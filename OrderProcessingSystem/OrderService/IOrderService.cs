using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.OrderService
{
    public interface IOrderService
    {
        void PublishOrder(OrderModel order);
    }
}
