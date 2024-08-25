using Soa.FineGrain;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IProductService, ProductService>();
var app = builder.Build();


app.MapGet("/api/products", (IProductService products) => products.GetAllProducts());

app.Run();
