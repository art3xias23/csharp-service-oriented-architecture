using Soa.FineGrain.Services;
using Soa.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
var app = builder.Build();


app.MapGet("/api/products", (IProductService products) => products.GetAllProducts());
app.MapGet("/api/orders", (IOrderService orders) => orders.GetOrders());
app.MapGet("/api/catalog", (ICatalogService catalog) => catalog.GetCatalog());
app.MapGet("/api/catalog-item/{id}", (int id, ICatalogService catalog) => catalog.GetCatalogItem(id));

app.Run();
