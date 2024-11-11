using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Mapper.OrderMapper;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.OrderService;

namespace OrderProcessingSystem.UseCases.OrderCreate
{
    public class OrderCreate : IOrderCreate
    { 
        readonly IOrderMapper _orderMapper;

        readonly IOrderService _orderService;
        public OrderCreate(IOrderMapper orderMapper, IOrderService orderService)
        {
            this._orderMapper = orderMapper;
            this._orderService = orderService;
        }

        void IOrderCreate.CreateOrder(OrderRequest orderRequest)
        {
            try
            { 
                OrderModel orderModel = this._orderMapper.MapToOrderModel(orderRequest);
                _orderService.PublishOrder(orderModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                throw new ApplicationException("Ocorreu um erro inesperado ao criar o pedido.", ex);
            }

        }
    }
}
