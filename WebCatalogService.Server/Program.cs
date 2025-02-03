using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Serialization;
using System.Data.Entity;
using System.Reflection.Metadata;
using WebCatalogService.Server;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Repositories;
using Microsoft.EntityFrameworkCore;

var serviceProvider = new ServiceProviderFactory().Create();
var builder = WebApplication.CreateBuilder(args);

using (var db = new WebCatalogDbContext(new DbContextOptions<WebCatalogDbContext>()))
{

    var product = new Product { Id = Guid.NewGuid(), Name = "TestProduct", Code = "11-1111-A111", Category = "Товары", Price = 100 };
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
builder.Services.AddTransient<IOrdersService, OrdersRepository>();
builder.Services.AddTransient<ICartService, CartRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(c =>
 c.AddPolicy("AllowOrigin", options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
 );
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 0;
    options.Password.RequireNonAlphanumeric = false;

})
    .AddEntityFrameworkStores<WebCatalogDbContext>()
    .AddRoles<User>();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();
app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Менеджер", "Заказчик" };
    foreach(var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

app.Run();
