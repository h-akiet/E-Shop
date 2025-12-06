namespace ShopApi.Models.ApiModels
{
    using ShopApi.Models.Entities;

    public class CategoryModel : Category
    {
        public CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.Name = category.Name;
            this.Description = category.Description;
            this.ProductCount = 0;
        }

        public int ProductCount { get; set; }

        public Category ConvertCategory()
        {
            return new Category
            {
                CategoryId = this.CategoryId,
                Name = this.Name,
                Description = this.Description,
            };
        }
    }
}
