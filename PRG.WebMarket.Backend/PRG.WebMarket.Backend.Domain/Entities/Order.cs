namespace PRG.WebMarket.Backend.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Total { get; set; }
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }
}
