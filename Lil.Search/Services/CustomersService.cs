using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<Customer?> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("customersService");

            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode) { 
                var content = await response.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Customer>(content);

                return customer;
            }

            return null;
        }
    }
}
