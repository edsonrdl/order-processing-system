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

        // Mapper de OrderModel para OrderResponse
        public static OrderResponse MapToOrderResponse(OrderModel model)
        {
            return new OrderResponse
            {
                ProductName = model.ProductName,
                Quantity = model.Quantity,
                Status = model.Status
            };
        }

        // Mapper de OrderModel para OrderRequest (caso necessário)
        public static OrderRequest MapToOrderRequest(OrderModel model)
        {
            return new OrderRequest
            {
                ProductName = model.ProductName,
                Quantity = model.Quantity
            };
        }

        // Mapper de OrderResponse para OrderModel (caso necessário)
        public static OrderModel MapToOrderModel(OrderResponse response)
        {
            return new OrderModel
            {
                ProductName = response.ProductName,
                Quantity = response.Quantity,
                Status = response.Status,
                OrderId = Guid.NewGuid(), // Ajuste conforme necessário
                CreatedAt = DateTime.UtcNow // Ajuste conforme necessário
            };
        }
    }
}
