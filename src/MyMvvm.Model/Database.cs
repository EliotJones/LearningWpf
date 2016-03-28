namespace MyMvvm.Model
{
    using System.Collections.Generic;
    using System.Data;
    using Npgsql;

    public class Database
    {
        private readonly NpgsqlConnection connection;
        public string Name { get; private set; }

        public Database(NpgsqlConnection connection, string name)
        {
            this.connection = connection;
            Name = name;
        }

        public IEnumerable<Table> GetTables()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            connection.ChangeDatabase(Name);

            var command = new NpgsqlCommand("SELECT table_name FROM information_schema.tables;", connection);

            var adapter = new NpgsqlDataAdapter(command);

            var dataSet = new DataSet();

            adapter.Fill(dataSet);

            return dataSet.Tables[0].AsEnumerable().Select(r => new Table(connection, r.Field<string>(0)));
        } 
    }
}