using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Tests
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _controller;

        public ProductsControllerTest()
        {
            var productsProvider = new ProductsProvider();
            _controller = new ProductsController(productsProvider);
        }


        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var result = await _controller.GetAsync("2");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            var result = await _controller.GetAsync("1000");

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}