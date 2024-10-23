using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(string orderDetails);
        void ProcessPayment(string paymentDetails);
        void NotifyUser(string notificationDetails);
    }
}
