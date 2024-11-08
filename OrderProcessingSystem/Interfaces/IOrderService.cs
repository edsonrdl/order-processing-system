using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderModel order);
    }
}
