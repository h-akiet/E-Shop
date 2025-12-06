namespace ShopApi.Models.ApiModels
{
    using ShopApi.Models.Entities;

    public class ProductModel : Product
    {
        public string Type { get; set; } = null!;
    }
}
