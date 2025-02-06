using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserManager<User> userManager;
        private SignInManager<User> singInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.singInManager = signInManager;
        }

        [HttpPost]
        public async Task<JsonResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (userManager.Users.FirstOrDefault(u => u.UserName == user.UserName) == null)
                {
                    return new JsonResult("Неверный логин и/или пароль");
                }
                var result = await singInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, isPersistent: false, lockoutOnFailure: false);
                
                if (result.Succeeded)
                {
                    return new JsonResult("Пользователь успешно авторизован");
                }
            }
            return new JsonResult("LoginFailed");
        }
    }
}
