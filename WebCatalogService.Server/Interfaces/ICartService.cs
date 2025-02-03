using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Interfaces
{
    public interface ICartService
    {
        JsonResult GetCart(Guid clientId);
        void AddToCart(Guid clientId, Product product, int quantity);
        void DeleteFromCart (Guid clientId, Guid productId);
    }
}
