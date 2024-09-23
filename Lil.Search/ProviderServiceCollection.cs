using Lil.Search.Interfaces;
using Lil.Search.Services;

namespace Lil.Search
{
    public static class ProviderServiceCollection
    {
        public static void AddSearchServices(this IServiceCollection services)
        {
            services.AddSingleton<ICustomersService,CustomersService>();
            services.AddSingleton<IProductsService, ProductsServices>();
            services.AddSingleton<ISalesService, SalesService>();
        }
    }
}
