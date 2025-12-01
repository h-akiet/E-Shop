using Microsoft.EntityFrameworkCore;
using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.Entities;

namespace ShopApi.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
