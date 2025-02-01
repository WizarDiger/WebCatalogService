namespace WebCatalogService.Server.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public string Role { get; set; }

    }
}
