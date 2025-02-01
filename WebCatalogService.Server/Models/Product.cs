namespace WebCatalogService.Server.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
