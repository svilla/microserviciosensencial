using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Sales.Tests
{
    public class SalesControllerTest
    {
        private readonly SalesController _controller;

        public SalesControllerTest()
        {
            var provider = new SalesProvider();
            _controller = new SalesController(provider);
        }


        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var result = await _controller.GetAsync("1");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            var result = await _controller.GetAsync("5");

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}