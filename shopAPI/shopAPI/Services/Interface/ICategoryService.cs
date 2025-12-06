namespace ShopApi.Services.Interface
{
    using ShopApi.Models.ApiModels;

    public interface ICategoryService
    {
        public List<CategoryModel> GetCategories();

        public CategoryModel? GetCategoryById(int id);

        public void AddCategory(CategoryModel category);

        public void UpdateCategory(CategoryModel category);

        public bool DeleteCategory(int id);
    }
}
