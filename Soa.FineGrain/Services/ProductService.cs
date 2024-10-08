﻿using Soa.FineGrain.Models;

namespace Soa.FineGrain.Services
{
    public class ProductService : IProductService
    {

        public IEnumerable<Product?> GetAllProducts()
        {
            return GetDummyProducts();

            //return _products;
        }

        private IEnumerable<Product?> GetDummyProducts()
        {
            var products = new List<Product>();

            Product product1 = new Product
            {
                Id = 1,
                Name = "Wireless Mouse",
                Price = 25.99m,
                Description = "A sleek and comfortable wireless mouse with long battery life."
            };

            products.Add(product1);


            Product product2 = new Product
            {
                Id = 2,
                Name = "Mechanical Keyboard",
                Price = 79.99m,
                Description = "A high-performance mechanical keyboard with customizable RGB lighting."
            };

            products.Add(product2);

            return products;
        }

        public Product? GetProductById(int id)
        {
            var products =  GetDummyProducts();
            return products.ToList().Find(p => p.Id == id);
        }
    }
}
