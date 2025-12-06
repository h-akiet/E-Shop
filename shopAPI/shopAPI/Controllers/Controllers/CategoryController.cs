namespace ShopApi.Controllers.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopApi.Models.ApiModels;
    using ShopApi.Services.Interface;

    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            List<CategoryModel> categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryModel category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            CategoryModel? category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel category)
        {
            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var success = _categoryService.DeleteCategory(id);

            if (success)
            {
                return Content("Success delete");
            }
            else
            {
                return StatusCode(500, "Failed to delete Category (Category is not exist or constrained by foreign key");
            }
        }
    }
}
