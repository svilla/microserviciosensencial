using Lil.Sales.DAL;
using Lil.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    public class SalesController: ControllerBase
    {
        private readonly ISalesProvider _provider;

        public SalesController(ISalesProvider salesProvider)
        {
            _provider = salesProvider;
        }


        [HttpGet("{customerId}")]
        [SwaggerOperation(Summary = "Get Orders by Customer ID", Description = "Return the details of a Order if exist")]
        [SwaggerResponse(200, "Orders Found", typeof(ICollection<Order>))]
        [SwaggerResponse(404, "Orders Not Found")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var orders = await _provider.GetAsync(customerId);

            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }

            return NotFound();
        }
    }
}
