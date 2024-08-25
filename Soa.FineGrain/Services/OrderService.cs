using System.Text.Json;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using Soa.FineGrain.Messages;
using Soa.FineGrain.Models;

namespace Soa.FineGrain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConnection _connection;
        public OrderService(IConnection connection)
        {
            _connection = connection; 
        }
    
        private List<Order> GetDummyOrders()
        {
            var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1001,
                OrderDate = DateTime.Now,
                Quantity = 3,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Wireless Mouse", Price = 25.99m, Description = "A sleek and comfortable wireless mouse with long battery life." },
                    new Product { Id = 2, Name = "Mechanical Keyboard", Price = 79.99m, Description = "A high-performance mechanical keyboard with customizable RGB lighting." }
                }
            },
            new Order
            {
                OrderId = 1002,
                OrderDate = DateTime.Now,
                Quantity = 5,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Wireless Mouse", Price = 25.99m, Description = "A sleek and comfortable wireless mouse with long battery life." },
                    new Product { Id = 3, Name = "USB-C Hub", Price = 45.00m, Description = "A versatile USB-C hub with multiple ports." }
                }
            },
            new Order
            {
                OrderId = 1003,
                OrderDate = DateTime.Now,
                Quantity = 4,
                Products = new List<Product>
                {
                    new Product { Id = 4, Name = "Gaming Monitor", Price = 199.99m, Description = "A 24-inch gaming monitor with a 144Hz refresh rate." }
                }
            }
        };
            return orders;
        }

        public List<Order> GetOrdersByProductId(int productId)
        {
            var orders = GetDummyOrders();
            return orders.Where(o => o.Products.Any(p => p.Id == productId)).ToList();
        }
        public List<Order> GetOrders()
        {
            var orders = GetDummyOrders();
            return orders;
        }

        public void PlaceOrder(int orderId, List<OrderItem> items)
        {
            var orderPlacedEvent = new OrderPlacedEvent
            {
                OrderId = orderId,
                Items = items
            };

            PublishOrderPlacedEvent(orderPlacedEvent);
        }

        private void PublishOrderPlacedEvent(OrderPlacedEvent orderPlacedEvent)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: "OrderPlacedQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var messageBody = JsonSerializer.Serialize(orderPlacedEvent);
            var body = System.Text.Encoding.UTF8.GetBytes(messageBody);

            channel.BasicPublish(exchange: "", routingKey: "OrderPlacedQueue", basicProperties: null, body: body);
            Console.WriteLine("Sent: " + messageBody);
        }
    }
}
