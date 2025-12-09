namespace ShopApi.Services
{
    using ShopApi.Models.Entities;
    using ShopApi.Services.Interface;

    public class PhysicalProductService : CaculateService
    {
        private readonly IProductService _productService;

        public PhysicalProductService(IProductService productService)
             : base(productService)
        {
            _productService = productService;
        }

        public override decimal CaculateTax(int productid)
        {
            Product? product = _productService.GetProduct(productid);
            if (product == null || !product.IsPhysical)
            {
                return 0;
            }

            return product.Price * 0.1M;
        }

        public override decimal CaculateAmount(List<int> productid)
        {
            decimal total = base.CaculateAmount(productid);
            decimal tax = 0;
            foreach (var id in productid)
            {
                tax += CaculateTax(id);
            }

            return total + tax;
        }
    }
}
