using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Dto;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreationDto orderDto)
        {
            var result = await _orderService.CreateOrder(orderDto);
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrder();
            return Ok(result);
        }

        [HttpGet("{idOrder:guid}")]
        public async Task<IActionResult> GetOrderById(Guid idOrder)
        {
            var result = await _orderService.GetById(idOrder);
            if (!result.Status)
                return NotFound(result.Mensagem);

            return Ok(result);
        }

        [HttpPut("{idOrder:guid}")]
        public async Task<IActionResult> UpdateOrder(Guid idOrder, [FromBody] OrderUpdateDto orderDto)
        {
            var result = await _orderService.UpdateOrder(idOrder, orderDto);
            if (!result.Status)
                return NotFound(result.Mensagem);

            return Ok(result);
        }

        [HttpDelete("{idOrder:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid idOrder)
        {
            var result = await _orderService.DeleteOrder(idOrder);
            if (!result.Status)
                return NotFound(result.Mensagem);

            return Ok(result);
        }
    }
}
