namespace ShopApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using ShopApi.Models.Entities;

    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        required public DbSet<Product> Products { get; set; }

        required public DbSet<Category> Categories { get; set; }

        required public DbSet<Order> Orders { get; set; }

        required public DbSet<OrderItem> OrderItems { get; set; }

        required public DbSet<User> Users { get; set; }
    }
}
