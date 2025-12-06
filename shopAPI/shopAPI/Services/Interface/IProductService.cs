namespace ShopApi.Services.Interface
{
    using ShopApi.Models.Entities;

    public interface IProductService
    {
        public Product GetProduct(int productId);

        public List<Product> GetProducts();

        public List<Product> GetProducts(string name);

        public void AddProduct(Product product);

        public void UpdateProduct(Product product);

        public bool DeleteProduct(Product product);
    }
}
