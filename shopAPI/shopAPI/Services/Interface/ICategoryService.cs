using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.ApiModels;
namespace ShopApi.Services.Interface
{
    public interface ICategoryService
    {
        public List<CategoryModel> GetCategories();
        public CategoryModel GetCategoryById(int id);
        public void AddCategory(CategoryModel category);

        public void UpdateCategory(CategoryModel category);
        public void DeleteCategory(int id);


    }
}
