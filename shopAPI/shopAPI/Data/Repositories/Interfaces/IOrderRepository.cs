
using ShopApi.Models.ApiModels;
using ShopApi.Models.Entities;

namespace ShopApi.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<OrderModel> GetByUserId(int id);
        public int AddOrder(Order order);
        public void updateOrder(Order order);
        public OrderModel? GetOrderById(int id);
        

    }
}
