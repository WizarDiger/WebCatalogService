using System.Data.Entity;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server
{
    public class WebCatalogDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
