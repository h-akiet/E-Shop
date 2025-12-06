namespace ShopApi.Controllers.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopApi.Models.Entities;
    using ShopApi.Services.Interface;

    [Route("/api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    InnerException = ex.InnerException?.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var success = _productService.DeleteProduct(product);
            if (success)
            {
                return Content("Success delete");
            }
            else
            {
                return StatusCode(500, "Failed to delete the product.");
            }
        }

        [HttpGet("search")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            var products = _productService.GetProducts(name);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(product);
            return NoContent();
        }
    }
}
