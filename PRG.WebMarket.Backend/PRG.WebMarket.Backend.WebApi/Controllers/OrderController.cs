using Microsoft.AspNetCore.Mvc;
using PRG.WebMarket.Backend.Domain.Contracts.Services;
using PRG.WebMarket.Backend.Domain.Model;
using PRG.WebMarket.Backend.WebApi.Controllers.Swagger;
using Swashbuckle.AspNetCore.Filters;

namespace PRG.WebMarket.Backend.WebApi.Controllers
{
    
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Crea una nueva orden de compra
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Respuesta indicando el éxito o fallo de la operación</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderModelExample))]
        [Produces("application/json")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel model)
        {
            var response = await _orderService.CreateOrderAsync(model);
            return CreatedAtAction(nameof(GetOrderById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Obtiene todas las ordenes
        /// </summary>
        /// <returns>Lista con todas las ordenes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderService.GetAllOrdersAsync();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene una orden por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderService.GetOrderByIdAsync(id);

            if (response == null)
                return NotFound($"No se encontró ninguna orden con el ID {id}");

            return Ok(response);
        }
    }
}
