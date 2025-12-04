using ShopApi.Models.Entities;
namespace ShopApi.Models.ApiModels
{
    public class ProductModel : Product
    {
        public string? DiscountedName { get; set; }
       
    }
}
