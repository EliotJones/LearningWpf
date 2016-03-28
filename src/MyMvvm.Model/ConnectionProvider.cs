namespace MyMvvm.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Npgsql;

    public class ConnectionProvider : IDisposable
    {
        private NpgsqlConnection connection;
        private string connectionString;

        public bool TestConnection(string username, string password, string host, int port)
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Username = username,
                Password = password,
                Port = port
            };

            var connection = new NpgsqlConnection(connectionStringBuilder);

            try
            {
                connection.Open();
                this.connection = connection;
                connectionString = connectionStringBuilder.ToString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HasConnection => connection != null;

        public void Dispose()
        {
            connection.Dispose();
        }

        public string ServerName => connection != null ? $"{connection.Host}:{connection.Port}" : "No connection";

        public IEnumerable<Database> GetDatabases()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            
            var command = new NpgsqlCommand("SELECT datname FROM pg_database WHERE datistemplate = false;", connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet.Tables[0].AsEnumerable().Select(r => new Database(connection, r.Field<string>(0)));
        }
    }
}
