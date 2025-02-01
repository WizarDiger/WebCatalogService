namespace WebCatalogService.Server.Models
{
    public class OrderElement
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemsCount { get; set; }
        public int ItemPrice { get; set; }
    }
}
