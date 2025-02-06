using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebCatalogService.Server.Interfaces;
using System.Data.SqlClient;
using WebCatalogService.Server.Models;
namespace WebCatalogService.Server.Repositories
{
    public class CurrentUserRepository:ICurrentUserService
    {
        private IConfiguration configuration;
        private string connectionString;
        public CurrentUserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("WebCatalogDbCon");
        }
        public JsonResult GetCurrentUser(string name)
        {
            string query = @"SELECT * FROM AspNetUsers WHERE ""UserName""=@userName";
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                using SqlCommand command = new SqlCommand(query, conn)
                {
                    Parameters =

                    {
                        new("@userName", name),

                    }
                };
                    var reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();

            }
            return new JsonResult(table);
        }
    }
}
