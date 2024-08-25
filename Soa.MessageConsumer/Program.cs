using RabbitMQ.Client;
using Soa.FineGrain.Messages;
using Soa.FineGrain.Services;
using Soa.Services;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
var orderService = new OrderService(connection);
var inventoryService = new InventoryService(connection);

inventoryService.StartListeningForOrderPlacedEvents();

var items = new List<OrderItem>
{
    new OrderItem { ProductId = 1, Quantity = 2 },
    new OrderItem { ProductId = 2, Quantity = 1 }
};
orderService.PlaceOrder(123, items);

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();