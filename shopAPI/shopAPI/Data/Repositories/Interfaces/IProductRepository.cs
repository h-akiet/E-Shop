using System.Security.Cryptography;
using ShopApi.Models.Entities;

namespace ShopApi.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public List<Product> GetProductByName(string name);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public Product? GetProductById(int id);

        

    }
}
