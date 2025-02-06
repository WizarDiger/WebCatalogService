using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using WebCatalogService.Server.Models;
using Microsoft.AspNetCore.Identity;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private IClientsService clientsService;


        public ClientsController(IClientsService clientsService)
        {

            this.clientsService = clientsService;

        }
        [HttpGet]
        public JsonResult GetClients()
        {
            return clientsService.GetClients();
        }
        [HttpPost]
        public JsonResult AddClient(Client client)
        {
            clientsService.AddClient(client);
            return new JsonResult("Клиент успешно создан");
        }
        [HttpPut]
        public JsonResult UpdateClient(Client client)
        {
            clientsService.UpdateClient(client);
            return new JsonResult("Информация о клиенте успешно обновлена");
        }

        [HttpDelete]
        public JsonResult DeleteUser(Client client)
        {
            clientsService.DeleteClient(client);
            return new JsonResult("Клиент успешно удалён");
        }
    }
}
