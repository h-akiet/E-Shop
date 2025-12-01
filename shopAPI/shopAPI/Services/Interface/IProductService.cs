using ShopApi.Models.Entities;

namespace ShopApi.Services.Interface
{
    public interface IProductService
    {
        public Product GetProduct(int productId);
        public List<Product> GetProducts();
        public List<Product> GetProducts(String name);
        

        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        

    }
}
