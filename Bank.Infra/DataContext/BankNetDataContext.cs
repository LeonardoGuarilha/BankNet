using System;
using System.Data;
using Bank.Shared;
using Npgsql;

namespace Bank.Infra.DataContext
{
    public class BankNetDataContext : IDisposable
    {
        
        public NpgsqlConnection Connection { get; set; }

        public BankNetDataContext()
        {
            Connection = new NpgsqlConnection(Configurations.ConnectionString);
            Connection.Open();
        }
        
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}