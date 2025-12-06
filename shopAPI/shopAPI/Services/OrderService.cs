namespace ShopApi.Services
{
    using ShopApi.Data.Repositories.Interfaces;
    using ShopApi.Models.ApiModels;
    using ShopApi.Models.Entities;
    using ShopApi.Services.Interface;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductService _productService;
        private readonly PhysicalProduct _physicalProduct;

        public OrderService(IOrderRepository order, IOrderItemRepository orderitem, IProductService productService, PhysicalProduct physicalProduct)
        {
            _orderRepository = order;
            _orderItemRepository = orderitem;
            _productService = productService;
            _physicalProduct = physicalProduct;
        }

        public void AddOrder(int userId, List<int> productId)
        {
            Order order = new Order();
            order.UserId = userId;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = _physicalProduct.CaculateAmount(productId);
            int orderid = _orderRepository.AddOrder(order);
            foreach (var id in productId)
            {
                Product product = _productService.GetProduct(id);
                var orderItem = new OrderItem
                {
                    OrderId = orderid,
                    ProductId = product.ProductId,
                    UnitPrice = product.Price,
                    Quantity = 1,
                };

                _orderItemRepository.AddOrderItem(orderItem);
            }
        }

        public List<OrderModel> GetByUserId(int id)
        {
            return _orderRepository.GetByUserId(id);
        }

        public OrderModel? GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }
    }
}
