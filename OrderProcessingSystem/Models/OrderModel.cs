using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public string ProductName {  get; set; }

        public int Quantity { get; set; }
         public OrderStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }

}
}
