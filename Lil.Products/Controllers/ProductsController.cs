using Lil.Products.DAL;
using Lil.Products.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductsProvider _productsProvider;

        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
            
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Product by ID", Description = "Return the details of a product if exist")]
        [SwaggerResponse(200, "Product Found", typeof(Product))]
        [SwaggerResponse(404, "Product Not Found")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _productsProvider.GetAsync(id);

            if (result != null) { 
                return Ok(result);
            }

            return NotFound();
        }
    }
}
