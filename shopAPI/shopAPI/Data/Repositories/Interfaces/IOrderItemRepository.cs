namespace ShopApi.Data.Repositories.Interfaces
{
    using ShopApi.Models.Entities;

    public interface IOrderItemRepository
    {
        public void AddOrderItem(OrderItem orderItem);

        public List<OrderItem> GetOrderItemsByOrderId(int orderId);
    }
}
