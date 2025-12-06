namespace ShopApi.Controllers.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopApi.Services.Interface;

    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetByUserId([FromQuery] int id)
        {
            var orders = _orderService.GetByUserId((int)id);
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult AddOrder(int userId, List<int> productId)
        {
            if (productId == null || productId.Count == 0)
            {
                return BadRequest("ProductId list cannot be null or empty.");
            }

            _orderService.AddOrder(userId, productId);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
