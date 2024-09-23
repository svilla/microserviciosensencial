namespace Lil.Customers.Models
{
    public class Customer
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? City { get; set; }
    }
}
