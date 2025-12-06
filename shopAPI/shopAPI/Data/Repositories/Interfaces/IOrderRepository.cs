namespace ShopApi.Data.Repositories.Interfaces
{
    using ShopApi.Models.ApiModels;
    using ShopApi.Models.Entities;

    public interface IOrderRepository
    {
        public List<OrderModel> GetByUserId(int id);

        public int AddOrder(Order order);

        public void UpdateOrder(Order order);

        public OrderModel? GetOrderById(int id);
    }
}
