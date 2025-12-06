namespace ShopApi.Data.Repositories
{
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.ApiModels;
    using ShopApi.Models.Entities;

    public class OrderRepository : IOrderRepository
    {
        private ShopContext _context;

        public OrderRepository(ShopContext context)
        {
            _context = context;
        }

        public int AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.OrderId;
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public List<OrderModel> GetByUserId(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            var orders = _context.Orders
                .Where(order => order.UserId == id)
                .Select(order => new OrderModel
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    Fullname = user != null ? user.Fullname : "Unknown",
                    Quantity = _context.OrderItems.Count(orderItem => orderItem.OrderId == order.OrderId),
                    Products = _context.OrderItems
                            .Where(orderItem => orderItem.OrderId == order.OrderId)
                            .Join(
                                  _context.Products,
                                  orderItem => orderItem.ProductId,
                                  product => product.ProductId,
                                  (orderItem, product) => product.Name)
                            .ToList(),
                    TotalAmount = order.TotalAmount,
                    UserId = order.UserId,
                }).ToList();
            return orders;
        }

        public OrderModel? GetOrderById(int id)
        {
            var model = _context.Orders
                .Where(o => o.OrderId == id)
                .Select(o => new OrderModel
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,

                    Fullname = _context.Users
                        .Where(u => u.UserId == o.UserId)
                        .Select(u => u.Fullname)
                        .FirstOrDefault(),

                    Quantity = _context.OrderItems
                        .Where(oi => oi.OrderId == o.OrderId)
                        .Count(),

                    Products = _context.OrderItems
                        .Where(oi => oi.OrderId == o.OrderId)
                        .Join(
                            _context.Products,
                            orderItem => orderItem.ProductId,
                            p => p.ProductId,
                            (oi, p) => p.Name)
                        .ToList(),
                    TotalAmount = o.TotalAmount,
                    UserId = o.UserId,
                })
                .FirstOrDefault();

            return model;
        }
    }
}
