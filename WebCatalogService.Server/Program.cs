using Newtonsoft.Json.Serialization;
using System.Data.Entity;
using System.Reflection.Metadata;
using WebCatalogService.Server;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Repositories;

var serviceProvider = new ServiceProviderFactory().Create();
var builder = WebApplication.CreateBuilder(args);

using (var db = new WebCatalogDbContext())
{

    var product = new Product { Id = Guid.NewGuid(), Name = "", Code = "", Category = "", Price = 0 };
    db.Products.Add(product);
    db.SaveChanges();

    // Display all Blogs from the database
    var query = from b in db.Products
                orderby b.Name
                select b;

    Console.WriteLine("All products in the database:");
    foreach (var item in query)
    {
        Console.WriteLine(item.Price);
    }
}

// Add services to the container.
builder.Services.AddTransient<IProductsService,ProductsRepository>();
builder.Services.AddTransient<IUsersService, UsersRepository>();
builder.Services.AddTransient<IClientsService, ClientsRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
