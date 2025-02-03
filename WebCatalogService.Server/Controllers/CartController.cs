using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet]
        public JsonResult GetCart(Guid clientId)
        {
            return cartService.GetCart(clientId);
        }
        [HttpPost]
        public JsonResult AddToCart(Guid clientId, Guid productId, string code, string name, int price, string category, int quantity)
        {
            var product = new Product() { Id = productId, Code = code, Name = name, Price = price, Category = category };
            cartService.AddToCart(clientId,product, quantity);
            return new JsonResult("Товар успешно добавлен в корзину");
        }
        [HttpDelete]
        public JsonResult DeleteFromCart(Guid clientId, Guid productId)
        {
            cartService.DeleteFromCart(clientId,productId);
            return new JsonResult("Товар успешно удалён из корзины");
        }
    }
}
