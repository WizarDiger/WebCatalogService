using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Interfaces
{
    public interface IClientsService
    {
        JsonResult GetClients();
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}
