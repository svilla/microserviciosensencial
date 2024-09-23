namespace Lil.Search.Models
{
    public class Order
    {
        public required string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public required string CustomerId { get; set; }
        public double Total { get; set; }
        public required List<OrderItem> Items { get; set; }
    }
}
