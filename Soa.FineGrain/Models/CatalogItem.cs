namespace Soa.FineGrain.Models
{
    public class CatalogItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockAvailable { get; set; }
    }
}
