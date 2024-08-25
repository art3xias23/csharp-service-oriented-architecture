using Soa.FineGrain.Models;

namespace Soa.FineGrain.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
