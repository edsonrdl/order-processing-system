using OrderProcessingSystem.Data;
using OrderProcessingSystem.Enum;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Service
{
    public class OrderService:IOrder
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<OrderModel>> CreateOrder(OrderCreationDto orderDto)
        {
            var newOrder = new OrderModel
            {
                OrderId = Guid.NewGuid(),
                ProductName = orderDto.ProductName,
                Quantity = orderDto.Quantity,
                Status = OrderStatusEnum.New,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return new ResponseModel<OrderModel> { Dados = newOrder, Mensagem = "Order created successfully" };
        }

        public async Task<ResponseModel<List<OrderModel>>> GetAllOrder()
        {
            var orders = await _context.Orders.ToListAsync();
            return new ResponseModel<List<OrderModel>> { Dados = orders, Mensagem = "Orders retrieved successfully" };
        }

        public async Task<ResponseModel<OrderModel>> GetById(Guid idOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == idOrder);

            if (order == null)
            {
                return new ResponseModel<OrderModel> { Mensagem = "Order not found", Status = false };
            }

            return new ResponseModel<OrderModel> { Dados = order, Mensagem = "Order retrieved successfully" };
        }

        public async Task<ResponseModel<OrderModel>> UpdateOrder(Guid idOrder, OrderUpdateDto orderDto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == idOrder);

            if (order == null)
            {
                return new ResponseModel<OrderModel> { Mensagem = "Order not found", Status = false };
            }

            order.ProductName = orderDto.ProductName;
            order.Quantity = orderDto.Quantity;
            order.Status = orderDto.Status;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return new ResponseModel<OrderModel> { Dados = order, Mensagem = "Order updated successfully" };
        }

        public async Task<ResponseModel<List<OrderModel>>> DeleteOrder(Guid idOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == idOrder);

            if (order == null)
            {
                return new ResponseModel<List<OrderModel>> { Mensagem = "Order not found", Status = false };
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            var remainingOrders = await _context.Orders.ToListAsync();
            return new ResponseModel<List<OrderModel>> { Dados = remainingOrders, Mensagem = "Order deleted successfully" };
        }
    }
}