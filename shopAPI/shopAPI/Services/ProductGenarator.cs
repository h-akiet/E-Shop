using ShopApi.Models.ApiModels;

namespace ShopApi.Services
{
    public abstract class ProductGenarator
    {
        public abstract ProductModel GetProductDetail();
    }

    public class PhysicalProduct : ProductGenarator
    {
        public override ProductModel GetProductDetail()
        {
            return new ProductModel
            {
                DiscountedName = "Physical Product"
            };
        }
    }
}
