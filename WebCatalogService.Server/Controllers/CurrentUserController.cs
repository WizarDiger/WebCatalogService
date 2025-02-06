using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentUserController : ControllerBase
    {

        private UserManager<User> userManager;
        private ICurrentUserService currentUserService;
        private SignInManager<User> signInManager;

        public CurrentUserController(UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
            this.userManager = userManager;
        }
        [HttpGet]
        public JsonResult GetCurrentUser()
        {
           // var userName = User.Identity.Name;
           // return currentUserService.GetCurrentUser(userName);
           return new JsonResult("");
        }

    }
}
