using Soa.FineGrain.Models;

namespace Soa.FineGrain.Services
{
    public interface ICatalogService
    {
        IEnumerable<CatalogItem> GetCatalog();
        CatalogItem GetCatalogItem(int productId);
    }

    public class CatalogService : ICatalogService
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CatalogService(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public IEnumerable<CatalogItem> GetCatalog()
        {
            var products = _productService.GetAllProducts();
            return products.Select(p => new CatalogItem
            {
                ProductId = p.Id,
                ProductName = p.Name,
                Price = p.Price,
                Description = p.Description,
                StockAvailable = GetStockForProduct(p.Id)
            });
        }

        public CatalogItem GetCatalogItem(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null) return null;

            return new CatalogItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Description = product.Description,
                StockAvailable = GetStockForProduct(product.Id)
            };
        }

        private int GetStockForProduct(int productId)
        {
            var orders = _orderService.GetOrdersByProductId(productId);
            int totalOrdered = orders.Sum(o => o.Quantity);
            return 100 - totalOrdered;
        }
    }
}
