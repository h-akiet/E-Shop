using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.ApiModels;
using ShopApi.Services.Interface;

namespace ShopApi.Controllers.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

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
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
