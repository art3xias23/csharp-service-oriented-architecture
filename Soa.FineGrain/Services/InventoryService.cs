using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Soa.FineGrain.Messages;

namespace Soa.Services
{
    public class InventoryService
    {
        private readonly IConnection _connection;

        public InventoryService(IConnection connection)
        {
            _connection = connection;
        }

        public void StartListeningForOrderPlacedEvents()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: "OrderPlacedQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);
                var orderPlacedEvent = JsonSerializer.Deserialize<OrderPlacedEvent>(message);

                UpdateInventory(orderPlacedEvent);
            };

            channel.BasicConsume(queue: "OrderPlacedQueue", autoAck: true, consumer: consumer);
        }

        private void UpdateInventory(OrderPlacedEvent orderPlacedEvent)
        {
            foreach (var item in orderPlacedEvent.Items)
            {
                Console.WriteLine($"Received: Updating inventory for ProductId: {item.ProductId}, Quantity: {item.Quantity}");
            }
        }
    }
}
