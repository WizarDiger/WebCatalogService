using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Repositories
{
    public class OrdersRepository:IOrdersService
    {
        private IConfiguration configuration;
        private string connectionString;
        public OrdersRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetOrders()
        {
            string query = $"SELECT * FROM Orders";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    var reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();

                }
            }
            return new JsonResult(table);
        }
        public void AddOrder(Order order)
        {
            string query = $@"INSERT INTO ""Orders"" (""Id"",""CustomerId"",""OrderDate"",""ShipmentDate"",""OrderNumber"",""Status"")
            VALUES (@id,@customerId,@orderDate,@shipmentDate,@orderNumber,@status)";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  Guid.NewGuid()),
                        new("@customerId", order.CustomerId),
                        new("@orderDate", order.OrderDate),
                        new("@shipmentDate", order.ShipmentDate),
                        new("@orderNumber", order.OrderNumber),
                        new("@status", order.Status)
                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }

        public void UpdateOrder(Order order)
        {
            string query = $@"UPDATE ""Orders"" SET ""CustomerId""=@customerId,""OrderDate""=@orderDate,""ShipmentDate""=@shipmentDate,""OrderNumber""=@orderNumber,""Status""=@status WHERE ""Id""=@id";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  order.Id),
                        new("@customerId", order.CustomerId),
                        new("@orderDate", order.OrderDate),
                        new("@shipmentDate", order.ShipmentDate),
                        new("@orderNumber", order.OrderNumber),
                        new("@status", order.Status)

                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
        public void DeleteOrder(Guid id)
        {
            string query = $@"DELETE FROM ""Order"" WHERE ""Id""=@id";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",id),
                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
    }
}
