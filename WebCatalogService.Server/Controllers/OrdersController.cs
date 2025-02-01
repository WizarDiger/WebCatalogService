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
        public JsonResult AddOrder(Guid customerId, DateTime shipmentDate)
        {
            var rnd = new Random();
            var order = new Order() { Id = Guid.NewGuid(),CustomerId = customerId, OrderDate=DateTime.Now,ShipmentDate = shipmentDate, OrderNumber = rnd.Next(0,100000),Status = "Новый" };
            ordersService.AddOrder(order);
            return new JsonResult("Заказ успешно сформирован");
        }
        [HttpPut]
        public JsonResult UpdateOrder(Guid id, Guid customerId, DateTime orderDate, DateTime shipmentDate, int orderNumber, string status)
        {
            var order = new Order() { Id = id, CustomerId = customerId, OrderDate = orderDate, ShipmentDate = shipmentDate, OrderNumber = orderNumber, Status = status };
            ordersService.UpdateOrder(order);
            return new JsonResult("Информация о заказе успешно обновлена");
        }
        [HttpDelete]
        public JsonResult DeleteOrder(Guid id, string status)
        {
            if (status == "Новый")
            {

                ordersService.DeleteOrder(id);
                return new JsonResult("Заказ был успешно удалён");
            }
            if (status == "Выполняется" || status == "Выполнен")
            {
                return new JsonResult("Невозможно удалить заказ, который уже выполняется или выполнен");
            }
            return new JsonResult("Некорректный статус заказа");
        }
    }
}
