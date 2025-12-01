using ShopApi.Models;
using ShopApi.Models.ApiModels;

namespace ShopApi.Services.Interface
{
    public interface IOrderService
    {
        public List<OrderModel> GetByUserId(int id);
        public void AddOrder(int userId, List<int> productId);
        public OrderModel GetOrderById(int id);


    }
}
