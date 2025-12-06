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

        public virtual decimal CaculateAmount(List<int> productid) {
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

    public class PhysicalProduct : CaculateService
    {
        public PhysicalProduct(IProductService productService)
             : base(productService)
        {
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

    public class DigitalProduct : CaculateService
    {
        public DigitalProduct(IProductService productService)
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