namespace ShopApi.Data.Repositories
{
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.Entities;

    public class ProductRepository : IProductRepository
    {
        private ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(Product product)
        {
            if (_context.OrderItems.Any(oi => oi.ProductId == product.ProductId))
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public List<Product> GetProductByName(string name)
        {
            return _context.Products.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}
