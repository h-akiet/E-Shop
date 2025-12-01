using Microsoft.AspNetCore.Mvc;
using ShopApi.Models.Entities;
using ShopApi.Services.Interface;
using Microsoft.Extensions.Logging;
using System.Net.NetworkInformation;

namespace ShopApi.Controllers.Controllers
{
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
        public IActionResult GetAll()
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
                    InnerException = ex.InnerException?.Message 
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(product);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult GetByName([FromQuery] string? name)
        {
            var products = _productService.GetProducts(name);
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
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
