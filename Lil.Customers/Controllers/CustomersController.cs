using Lil.Customers.DAL;
using Lil.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController:ControllerBase
    {
        private readonly ICustomersProvider _customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Customer by ID", Description = "Return the details of a customer if exist")]
        [SwaggerResponse(200, "Customer Found", typeof(Customer))]
        [SwaggerResponse(404, "Customer Not Found")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _customersProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

    }
}
