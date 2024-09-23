namespace Lil.Search.Models
{
    public class OrderItem
    {
        public required string OrderId { get; set; }
        public required string Id { get; set; }
        public required string ProductId { get; set; }
        public required int Quantity { get; set; }
        public required double Price { get; set; }

        public Product Product { get; set; }
    }
}
