﻿namespace Soa.FineGrain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }
    }
}
