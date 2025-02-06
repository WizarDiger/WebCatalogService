using Microsoft.AspNetCore.Mvc;

namespace WebCatalogService.Server.Interfaces
{
    public interface ICurrentUserService
    {
        JsonResult GetCurrentUser(string name);
    }
}
