
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using System.Data.Entity;
namespace WebCatalogService.Server.Models
{

    public class WebCatalogDbContext : IdentityDbContext<User>
    {
        public WebCatalogDbContext(DbContextOptions<WebCatalogDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }

    /*
    public class WebCatalogDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
    */
}
