namespace ShopApi.Data.Repositories
{
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.Entities;

    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            context.SaveChanges();
        }

        public bool DeleteCategory(Category category)
        {
            if (context.Products.Any(p => p.CategoryId == category.CategoryId))
            {
                return false;
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return context.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
