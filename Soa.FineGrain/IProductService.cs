namespace Soa.FineGrain
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
