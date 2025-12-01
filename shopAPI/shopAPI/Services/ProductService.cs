using System.Collections.Generic;
using ShopApi.Services.Interface;
using ShopApi.Data.Repositories;
using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.Entities;


namespace ShopApi.Services
{
    public class ProductService :  IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService (IProductRepository repository){
            _repository = repository;
        }
        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            _repository.DeleteProduct(product);
        }

        public Product GetProduct(int productId)
        {
            return _repository.GetProductById(productId);
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
