using Lil.Customers.DAL;

namespace Lil.Customers
{
    public static class ConfigureProviders
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddSingleton<ICustomersProvider, CustomersProvider>();
        }
    }
}
