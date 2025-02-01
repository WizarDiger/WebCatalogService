using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebCatalogService.Server.Models;
using WebCatalogService.Server.Interfaces;

namespace WebCatalogService.Server.Repositories
{
    public class UsersRepository:IUsersService
    {
        private IConfiguration configuration;
        private string connectionString;
        public UsersRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetUsers()
        {
            string query = $"SELECT * FROM Users";
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
        public void AddUser(User user)
        {
            string query = $@"INSERT INTO ""Users"" (""Id"",""Name"",""ClientId"",""Role"")
            VALUES (@id,@name,@clientId,@role)";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  Guid.NewGuid()),
                        new("@name", user.Name),
                        new("@clienId", user.ClientId),
                        new("@role", user.Role)
                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }

        public void UpdateUser(User user)
        {
            string query = $@"UPDATE ""Users"" SET ""Name""=@name,""ClientId""=@clientId,""Role""=@role WHERE ""Id""=@id";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using var command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@id",  user.Id),
                        new("@name", user.Name),
                        new("@clientId", user.ClientId),
                        new("@role", user.Role)

                    }
                };
                var reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
                conn.Close();
            }
        }
        public void DeleteUser(Guid id)
        {
            string query = $@"DELETE FROM ""Users"" WHERE ""Id""=@id";
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
