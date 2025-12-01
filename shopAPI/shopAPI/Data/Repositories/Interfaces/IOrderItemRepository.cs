using ShopApi.Models.Entities;
namespace ShopApi.Data.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        public void AddOrderItem(OrderItem orderItem);
        public List<OrderItem> GetOrderItemsByOrderId(int orderId);
       
    }
}
