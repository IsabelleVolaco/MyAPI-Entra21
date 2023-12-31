﻿using Dapper;
using MySql.Data.MySqlClient;

namespace MyAPI_Entra21.Infraestructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Database=backend;User=root;Password=root;";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        protected async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);  //async <-> await - para esperar 
            }
        }
    }
}