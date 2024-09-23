using Lil.Sales.DAL;

namespace Lil.Sales
{
    public static class ProviderServiceCollection
    {
        public static void AddSalesProvider(this IServiceCollection services)
        {
            services.AddSingleton<ISalesProvider, SalesProvider>();
        }
    }
}
