namespace ShopApi.Data.Repositories.Interfaces
{
    using ShopApi.Models.Entities;

    public interface IProductRepository
    {
        public List<Product> GetAll();

        public List<Product> GetProductByName(string name);

        public void AddProduct(Product product);

        public void UpdateProduct(Product product);

        public bool DeleteProduct(Product product);

        public Product? GetProductById(int id);
    }
}
