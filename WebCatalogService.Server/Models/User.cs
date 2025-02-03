using Microsoft.AspNetCore.Identity;

namespace WebCatalogService.Server.Models
{
    public class User:IdentityUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public string Role { get; set; }

    }
}
