using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Mapper.OrderMapper
{
    public interface IOrderMapper
    {
        OrderModel MapToOrderModel(OrderRequest request);


        OrderResponse MapToOrderResponse(OrderModel model);
        
        //void MapToOrderRequest(OrderModel model)
        //{
          
        //}
        //void MapToOrderModel(OrderResponse response)
        //{
          
        //}
    }
}