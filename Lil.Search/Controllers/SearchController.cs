using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController:ControllerBase
    {
        private readonly ICustomersService _customerService;
        private readonly IProductsService _productsService;
        private readonly ISalesService _salesService;

        public SearchController(ICustomersService customerService, IProductsService productsService, ISalesService salesService)
        {
           _customerService = customerService;
           _productsService = productsService;
           _salesService = salesService;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId) 
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest();
            }
            var customer = await _customerService.GetAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            var sales = await _salesService.GetAsync(customerId);

            foreach (var sale in sales)
            {
                foreach (var item in sale.Items)
                {
                    var product = await _productsService.GetAsync(item.ProductId);
                    item.Product = product;
                }
            }

            var result = new
            {
                Customer = customer,
                Sales = sales
            };

            return Ok(result);

        }
    }
}
