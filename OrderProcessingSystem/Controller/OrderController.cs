using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Mapper.OrderMapper;
using OrderProcessingSystem.UseCases.OrderCreate;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCreate _orderCreate;

        public OrderController(IOrderCreate iOrderCreate)
        {
            this._orderCreate = iOrderCreate;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderRequest orderRequest)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this._orderCreate.CreateOrder(orderRequest);

            return Ok("Pedido enviado para criação.");
        }
    }
}
