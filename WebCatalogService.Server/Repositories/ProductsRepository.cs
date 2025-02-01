using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebCatalogService.Server.Repositories
{
    public class ProductsRepository:IProductsService
    {
        private IConfiguration configuration;
        private string connectionString;
        public ProductsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetProducts()
        {
            string query = $"SELECT * FROM Products";
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
        public void AddProduct(Product product)
        {
            string query = $@"INSERT INTO ""Products"" (""Id"", ""Code"",""Name"",""Price"",""Category"")
            VALUES (@id,@code,@name,@price,@category)";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  Guid.NewGuid()),
                        new("@code", product.Code),
                        new("@name", product.Name),
                        new("@price", product.Price),
                        new("@category", product.Category)

                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }

        public void UpdateProduct(Product product)
        {
            string query = $@"UPDATE ""Products"" SET ""Code""=@code,""Name""=@name,""Price""=@price,""Category""=@category WHERE ""Id""=@id";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  product.Id),
                        new("@code", product.Code),
                        new("@name", product.Name),
                        new("@price", product.Price),
                        new("@category", product.Category)

                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
        public void DeleteProduct(Guid id)
        {
            string query = $@"DELETE FROM ""Products"" WHERE ""Id""=@id";
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
