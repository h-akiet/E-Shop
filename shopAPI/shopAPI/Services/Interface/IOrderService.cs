namespace ShopApi.Services.Interface
{
    using ShopApi.Models.ApiModels;

    public interface IOrderService
    {
        public List<OrderModel> GetByUserId(int id);

        public void AddOrder(int userId, List<int> productId);

        public OrderModel? GetOrderById(int id);
    }
}
