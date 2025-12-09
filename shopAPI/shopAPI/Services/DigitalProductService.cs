namespace ShopApi.Services
{
    using ShopApi.Services.Interface;

    public class DigitalProductService : CaculateService
    {
        public DigitalProductService(IProductService productService)
             : base(productService)
        {
        }

        public override decimal CaculateTax(int productid)
        {
            return 0;
        }

        public override decimal CaculateAmount(List<int> productid)
        {
            return base.CaculateAmount(productid);
        }
    }
}
