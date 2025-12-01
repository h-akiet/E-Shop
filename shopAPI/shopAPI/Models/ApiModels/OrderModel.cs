using ShopApi.Models.Entities;

namespace ShopApi.Models.ApiModels
{
    public class OrderModel : Order
    {

        public string? Fullname { get; set; } = null!;
        public int Quantity { get; set; }
        public List<String> Products { get; set; } = new List<String>();
    }
}
