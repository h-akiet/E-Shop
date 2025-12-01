using ShopApi.Models.Entities;
namespace ShopApi.Models.ApiModels
{
    public class CategoryModel : Category
    {
        public int ProductCount { get; set; }

        public CategoryModel(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.Name = category.Name;
            this.Description = category.Description;
            this.ProductCount = 0;
        }
        public CategoryModel()
        {
        }
        public Category ConvertCategory()
        {
            return new Category
            {
                CategoryId = this.CategoryId,
                Name = this.Name,
                Description = this.Description
            };

        }
        

    }
}
