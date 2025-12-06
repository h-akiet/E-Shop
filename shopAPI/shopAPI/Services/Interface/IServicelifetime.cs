namespace ShopApi.Services.Interface
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IServicelifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
