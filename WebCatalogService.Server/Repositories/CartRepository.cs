using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Repositories
{
    public class CartRepository:ICartService
    {
        private IConfiguration configuration;
        private string connectionString;
        public CartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetCart(Guid clientId)
        {
            string query = $@"SELECT * FROM Card WHERE ""ClientId"" = @clientId";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@clientId",clientId)
                    }
                };
                    var reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();
            }
            return new JsonResult(table);
        }
        public void AddToCart(Guid clientId, Product product, int quantity)
        {
            string query = $@"INSERT INTO ""Cart"" (""ClientId"",""ProductId"",""Code"",""Name"",""Price"",""Category"",""Quantity"")
            VALUES (@clientId,@productId,@code,@name,@price,@category,@quantity)";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@clientId",  clientId),
                        new("@productId", product.Id),
                        new("@code", product.Code),
                        new("@name", product.Name),
                        new("@price", product.Price),
                        new("@category", product.Category),
                        new("@quantity", quantity)
                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
        public void DeleteClient(Guid clientId, Guid productId)
        {
            string query = $@"DELETE FROM ""Cart"" WHERE ""ClientId""=@clientId AND ""ProductId""=@productId";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@clientId",clientId),
                        new("@productId",productId)

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
