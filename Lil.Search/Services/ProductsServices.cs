using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class ProductsServices : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<Product?> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("productsService");

            var response =  await client.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return product;
            }

            return null;
        }
    }
}
