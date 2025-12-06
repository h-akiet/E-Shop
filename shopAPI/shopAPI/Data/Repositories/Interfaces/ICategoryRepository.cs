namespace ShopApi.Data.Repositories.Interfaces
{
    using ShopApi.Models.Entities;

    public interface ICategoryRepository
    {
        List<Category> GetAll();

        void AddCategory(Category category);

        bool DeleteCategory(Category category);

        Category? GetCategoryById(int id);

        void UpdateCategory(Category category);
    }
}
