using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Interfaces
{
    public interface IOrdersService
    {
        JsonResult GetOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
