using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();

        public SalesProvider()
        {

            repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-10),
                Total = 200,
                Items = new List<OrderItem>()
                {
                    new OrderItem() { OrderId = "001", Id = "1", Price= 25, ProductId = "80", Quantity= 2 },
                    new OrderItem() { OrderId = "001", Id = "2", Price= 50, ProductId = "56", Quantity= 1 },
                    new OrderItem() { OrderId = "001", Id = "3", Price= 50, ProductId = "41", Quantity= 1 }
                }
            });


            repo.Add(new Order()
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-2),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem() { OrderId = "002", Id = "5", Price= 15, ProductId = "1", Quantity= 2 },
                    new OrderItem() { OrderId = "002", Id = "6", Price= 20, ProductId = "33", Quantity= 1 },
                    new OrderItem() { OrderId = "002", Id = "7", Price= 50, ProductId = "40", Quantity= 1 }
                }
            });


            repo.Add(new Order()
            {
                Id = "0004",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddDays(-10),
                Total = 50,
                Items = new List<OrderItem>()
                {
                    new OrderItem() { OrderId = "004", Id = "8", Price= 15, ProductId = "1", Quantity= 2 },
                    new OrderItem() { OrderId = "004", Id = "9", Price= 20, ProductId = "33", Quantity= 1 }
                }
            });
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(o => o.CustomerId == customerId).ToList();

            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
