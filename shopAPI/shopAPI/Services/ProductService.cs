namespace ShopApi.Services
{
    using System.Collections.Generic;
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.Entities;
    using ShopApi.Services.Interface;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public bool DeleteProduct(Product product)
        {
            return _repository.DeleteProduct(product);
        }

        public Product GetProduct(int productId)
        {
            var product = _repository.GetProductById(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        public List<Product> GetProducts(string name)
        {
            return _repository.GetProductByName(name);
        }
    }
}
