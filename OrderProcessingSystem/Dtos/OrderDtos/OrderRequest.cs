using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Dtos.OrderDtos
{
    public class OrderRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

    }
}
