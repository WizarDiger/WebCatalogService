using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService usersService;
        private IClientsService clientsService;

        public UsersController(IUsersService usersService, IClientsService clientsService)
        {
            this.usersService = usersService;
            this.clientsService = clientsService;
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            return usersService.GetUsers();
        }
        [HttpPost]
        public JsonResult AddUser(string name, string role, string code, string address, int discount)
        {
            if (role == "Заказчик")
            {
                var guid = Guid.NewGuid();
                var user = new User() { Id = guid, Name = name, ClientId = guid, Role = role};
                usersService.AddUser(user);
                var client = new Client() { Id = guid, Name = name, Code = code, Address = address, Discount = discount };
                clientsService.AddClient(client);
            }
            if (role == "Менеджер")
            {
                var user = new User() { Id = Guid.NewGuid(), Name = name, Role = role };
                usersService.AddUser(user);
            }
            return new JsonResult("Пользователь успешно создан");
        }
        [HttpPut]
        public JsonResult UpdateUser(Guid id, string name, string role, string code, string address, int discount)
        {
            var user = new User() { Id = id, Name = name, ClientId = id, Role = role };
            usersService.UpdateUser(user);
            var client = new Client() { Id = id, Name = name, Code = code, Address = address, Discount = discount };
            clientsService.UpdateClient(client);
            return new JsonResult("Информация о пользователе успешно обновлена");
        }
        [HttpDelete]
        public JsonResult DeleteUser(Guid id)
        {
            usersService.DeleteUser(id);
            clientsService.DeleteClient(id);
            return new JsonResult("Пользователь успешно удалён");
        }
    }
}
