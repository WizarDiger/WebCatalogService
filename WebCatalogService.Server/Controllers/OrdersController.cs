using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCatalogService.Server.Interfaces;
using WebCatalogService.Server.Models;

namespace WebCatalogService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersService ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        [HttpGet]
        public JsonResult GetOrders()
        {
            return ordersService.GetOrders();
        }
        [HttpPost]
        public JsonResult AddOrder(Order order)
        {
            var rnd = new Random();
            var myOrder = new Order() { Id = Guid.NewGuid(),CustomerId = order.CustomerId, OrderDate=DateTime.Now,ShipmentDate = order.ShipmentDate, OrderNumber = rnd.Next(0,100000),Status = "Новый" };
            ordersService.AddOrder(order);
            return new JsonResult("Заказ успешно сформирован");
        }
        [HttpPut]
        public JsonResult UpdateOrder(Order order)
        {
            ordersService.UpdateOrder(order);
            return new JsonResult("Информация о заказе успешно обновлена");
        }
        [HttpDelete]
        public JsonResult DeleteOrder(Order order)
        {
            if (order.Status == "Новый")
            {

                ordersService.DeleteOrder(order);
                return new JsonResult("Заказ был успешно удалён");
            }
            if (order.Status == "Выполняется" || order.Status == "Выполнен")
            {
                return new JsonResult("Невозможно удалить заказ, который уже выполняется или выполнен");
            }
            return new JsonResult("Некорректный статус заказа");
        }
    }
}
