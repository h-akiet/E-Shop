namespace ShopApi.Data.Repositories
{
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.Entities;

    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ShopContext _context;

        public OrderItemRepository(ShopContext context)
        {
            _context = context;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return _context.OrderItems.Where(orderItem => orderItem.OrderId == orderId).ToList();
        }
    }
}
