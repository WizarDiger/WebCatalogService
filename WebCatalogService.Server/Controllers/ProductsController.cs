using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Repositories;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        [HttpGet]
        public JsonResult GetProducts()
        {
            return productsService.GetProducts();
        }
        [HttpPost]
        public JsonResult AddProduct(string code, string name, int price, string category)
        {
            var product = new Product() { Id = Guid.NewGuid(), Code = code, Name = name, Price = price, Category = category };
            productsService.AddProduct(product);
            return new JsonResult("Товар успешно добавлен");
        }
        [HttpPut]
        public JsonResult UpdateProduct(Guid id, string code, string name, int price, string category)
        {
            var product = new Product() { Id = id, Code = code, Name = name, Price = price, Category = category };
            productsService.UpdateProduct(product);
            return new JsonResult("Информация о товаре успешно обновлена");
        }
        [HttpDelete]
        public JsonResult DeleteProduct(Guid id)
        {
            productsService.DeleteProduct(id);
            return new JsonResult("Продукт успешно удалён");
        }
    }
}
