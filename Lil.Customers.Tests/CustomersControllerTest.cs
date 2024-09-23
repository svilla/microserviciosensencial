using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Tests
{
    public class CustomersControllerTest
    {
        private readonly CustomersController _controller;

        public CustomersControllerTest()
        {
            var provider = new CustomersProvider();
            _controller = new CustomersController(provider);
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
            var result = await _controller.GetAsync("100");

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}