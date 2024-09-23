using Lil.Search.Controllers;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Lil.Search.Tests
{
    public class SearchControllerTest
    {
        private readonly SearchController _controller;
        private readonly Mock<ICustomersService> _customersService;
        private readonly Mock<IProductsService> _productsService;
        private readonly Mock<ISalesService> _salesService;

        public SearchControllerTest()
        {
            _customersService = new Mock<ICustomersService>();
            _productsService = new Mock<IProductsService>();
            _salesService= new Mock<ISalesService>();

            _controller = new SearchController(_customersService.Object,_productsService.Object,_salesService.Object);

        }


        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var product = new Product { Id = "1", Name = "Product1", Price = 50 };
            _customersService.Setup(cs => cs.GetAsync("2")).ReturnsAsync(new Customer { Id = "1", Name = "Aja", City = "City1" });
            _salesService.Setup(ss => ss.GetAsync("2")).ReturnsAsync([new() {
                Id = "1",
                CustomerId = "2",
                OrderDate = DateTime.Now,
                Total = 50,
                Items = [new OrderItem { Id = "1", OrderId = "1", Price = 50, ProductId = "1", Quantity = 1, Product = product }]
            } ]);
            _productsService.Setup(ps => ps.GetAsync("1")).ReturnsAsync(product);


            var result = await _controller.SearchAsync("2");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetAsyncReturnBadRequest()
        {
            var result = await _controller.SearchAsync(string.Empty);

            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            _customersService.Setup(cs => cs.GetAsync("1")).ReturnsAsync((Customer)null);

            var result = await _controller.SearchAsync("1");

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}