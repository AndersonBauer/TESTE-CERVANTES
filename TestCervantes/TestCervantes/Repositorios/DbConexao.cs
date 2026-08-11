using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestCervantes.Repositorios
{
    public class DbConexao : IDisposable
    {
        private readonly IDbConnection connection;

        public DbConexao()
        {
            connection = new NpgsqlConnection("" +
                "Host=localhost;Port=5432;Database=VeiculosDB;Username=postgres;Password=123456;");
        }

        public IDbConnection GetConnection()
        {
            if(connection.State != ConnectionState.Open)
                connection.Open();
            
            return connection;
        }

        public void Dispose() 
        { 
            connection?.Dispose();
        }
    }
}
