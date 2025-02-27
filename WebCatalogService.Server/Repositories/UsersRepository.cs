﻿using Microsoft.AspNetCore.Mvc;
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
            string query = $"SELECT * FROM AspNetUsers";
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

    }
}
