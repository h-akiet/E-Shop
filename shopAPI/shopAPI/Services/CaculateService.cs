namespace ShopApi.Services
{
    using ShopApi.Models.Entities;
    using ShopApi.Services.Interface;

    public abstract class CaculateService
    {
        protected readonly IProductService _productService;

        public CaculateService(IProductService productService)
        {
            _productService = productService;
        }

        public virtual decimal CaculateAmount(List<int> productid)
        {
            decimal total = 0;
            foreach (var id in productid)
            {
                Product? product = _productService.GetProduct(id);
                if (product == null)
                {
                    total += 0;
                }
                else
                {
                    total += product.Price;
                }
            }

            return total;
        }

        public abstract decimal CaculateTax(int productid);
    }
}