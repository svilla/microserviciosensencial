using Lil.Products.DAL;

namespace Lil.Products
{
    public static class ProviderServiceCollection
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddSingleton<IProductsProvider, ProductsProvider>();
        }
    }
}
