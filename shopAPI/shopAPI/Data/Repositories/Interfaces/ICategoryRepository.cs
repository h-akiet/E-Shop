using ShopApi.Models.Entities;
namespace ShopApi.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        Category? GetCategoryById(int id);
        void UpdateCategory(Category category);
    }
}
