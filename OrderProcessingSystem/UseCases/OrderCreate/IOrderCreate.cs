using OrderProcessingSystem.Dtos.OrderDtos;

namespace OrderProcessingSystem.UseCases.OrderCreate
{
    public interface IOrderCreate
    {
        void CreateOrder(OrderRequest orderRequest);
    }
}
