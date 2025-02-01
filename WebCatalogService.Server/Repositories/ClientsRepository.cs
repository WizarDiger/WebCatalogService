using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Repositories
{
    public class ClientsRepository:IClientsService
    {
        private IConfiguration configuration;
        private string connectionString;
        public ClientsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetClients()
        {
            string query = $"SELECT * FROM Clients";
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
        public void AddClient(Client client)
        {
            string query = $@"INSERT INTO ""Clients"" (""Id"",""Name"",""Code"",""Address"",""Discount"")
            VALUES (@id,@name,@code,@address,@discount)";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  Guid.NewGuid()),
                        new("@name", client.Name),
                        new("@code", client.Code),
                        new("@address", client.Address),
                        new("@discount", client.Discount)
                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }

        public void UpdateClient(Client client)
        {
            string query = $@"UPDATE ""Client"" SET ""Name""=@name,""Code""=@code,""Address""=@address,""Discount""=@discount WHERE ""Id""=@id";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  client.Id),
                        new("@name", client.Name),
                        new("@code", client.Code),
                        new("@address", client.Address),
                        new("@discount", client.Discount)

                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
        public void DeleteClient(Guid id)
        {
            string query = $@"DELETE FROM ""Clients"" WHERE ""Id""=@id";
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
