using Soa.FineGrain.Models;

namespace Soa.FineGrain.Services;

public interface IOrderService
{
    List<Order> GetOrdersByProductId(int productId);
    List<Order> GetOrders();
}