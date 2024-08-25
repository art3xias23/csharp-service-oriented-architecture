namespace Soa.FineGrain.Messages
{
    public class OrderPlacedEvent
    {
        public int OrderId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
