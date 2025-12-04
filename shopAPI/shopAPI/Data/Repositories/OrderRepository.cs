using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.ApiModels;
using ShopApi.Models.Entities;

namespace ShopApi.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ShopContext _context;
        public OrderRepository (ShopContext context)
        {
            _context = context;
        }

        public int AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.OrderId;

        }
        public void updateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            }

        public List<OrderModel> GetByUserId(int id)
        {

            var dtos = _context.Orders
                .Where(o => o.UserId == id)
                .Select(o => new OrderModel
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    Fullname = _context.Users.FirstOrDefault(u => u.UserId == o.UserId).Fullname,
                    Quantity = _context.OrderItems.Count(oi => oi.OrderId == o.OrderId),
                    Products = _context.OrderItems
                            .Where(oi => oi.OrderId == o.OrderId)
                            .Join(_context.Products,
                                  oi => oi.ProductId,
                                  p => p.ProductId,
                                  (oi, p) => p.Name)
                            .ToList(),
                    TotalAmount = o.TotalAmount,
                    UserId = o.UserId

                }).ToList();
                return dtos;

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
                            oi => oi.ProductId,
                            p => p.ProductId,
                            (oi, p) => p.Name
                        )
                        .ToList(),
                    TotalAmount = o.TotalAmount,
                    UserId = o.UserId

                })
                .FirstOrDefault();   

            return model;
        }

    }
}
