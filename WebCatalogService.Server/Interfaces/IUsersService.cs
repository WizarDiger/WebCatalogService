using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Interfaces
{
    public interface IUsersService
    {
        JsonResult GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}
