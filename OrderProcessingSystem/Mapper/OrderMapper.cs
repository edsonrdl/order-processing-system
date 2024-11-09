using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Enum;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Mapper
{
    public class OrderMapper
    {
        // Mapper de OrderRequest para OrderModel
        public static OrderModel MapToOrderModel(OrderRequest request)
        {
            return new OrderModel
            {
                OrderId = Guid.NewGuid(), 
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Status = OrderStatusEnum.Pending, 
                CreatedAt = DateTime.UtcNow 
            };
        }

        public static OrderResponse MapToOrderResponse(OrderModel model)
        {
            return new OrderResponse
            {
                ProductName = model.ProductName,
                Quantity = model.Quantity,
                Status = model.Status
            };
        }
        public static OrderRequest MapToOrderRequest(OrderModel model)
        {
            return new OrderRequest
            {
                ProductName = model.ProductName,
                Quantity = model.Quantity
            };
        }
        public static OrderModel MapToOrderModel(OrderResponse response)
        {
            return new OrderModel
            {
                ProductName = response.ProductName,
                Quantity = response.Quantity,
                Status = response.Status,
                OrderId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow 
            };
        }
    }
}
