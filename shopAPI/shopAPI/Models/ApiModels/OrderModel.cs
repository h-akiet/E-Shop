namespace ShopApi.Models.ApiModels
{
    using ShopApi.Models.Entities;

    public class OrderModel : Order
    {
        public string? Fullname { get; set; } = null!;

        public int Quantity { get; set; }

        public List<string> Products { get; set; } = new List<string>();
    }
}
