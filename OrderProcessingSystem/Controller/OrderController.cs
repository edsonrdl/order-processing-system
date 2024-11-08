using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Mapper;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Service;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderRequest orderRequest)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            OrderModel orderModel = OrderMapper.MapToOrderModel(orderRequest);

            _orderService.CreateOrder(orderModel);

            return Ok("Pedido enviado para criação.");
        }
    }
}
