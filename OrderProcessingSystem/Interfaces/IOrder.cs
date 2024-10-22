using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Interfaces
{
    public interface IOrder
    {
        Task<ResponseModel<OrderModel>> CreateOrder();
        Task<ResponseModel<List<OrderModel>>> GetAllOrder();

        Task<ResponseModel<OrderModel>> GetById(Guid idOrder);
        Task<ResponseModel<OrderModel>> UpdateOrder(Guid idOrder);
        /Task<ResponseModel<List<OrderModel>>> DeleteOrder(Guid idOrder);
    }
}
