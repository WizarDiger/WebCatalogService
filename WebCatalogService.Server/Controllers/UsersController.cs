using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<User> userManager;

        public UsersController(IUsersService usersService, IClientsService clientsService, UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.clientsService = clientsService;
            this.userManager = userManager;
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            return usersService.GetUsers();
        }
        [HttpPost]
        public JsonResult AddUser(User user)
        {

            userManager.CreateAsync(user);
            userManager.AddToRoleAsync(user, "Заказчик");

            return new JsonResult("Пользователь успешно создан");
        }
        [HttpPut]
        public JsonResult UpdateUser(User user)
        {
            userManager.UpdateAsync(user);
            return new JsonResult("Информация о пользователе успешно обновлена");
        }
        [HttpDelete]
        public JsonResult DeleteUser(User user)
        {
            userManager.DeleteAsync(user);
            return new JsonResult("Пользователь успешно удалён");
        }
    }
}
