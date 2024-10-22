using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Dtos.OrderDtos
{
    public class OrderResponse
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}
