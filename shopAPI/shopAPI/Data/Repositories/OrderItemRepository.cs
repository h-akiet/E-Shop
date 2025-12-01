using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.Entities;

namespace ShopApi.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ShopContext _context;
        public OrderItemRepository(ShopContext context) {
            _context = context;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
           
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
        }
    }
}
