namespace MyMvvm.Model
{
    using Npgsql;

    public class Table
    {
        private readonly NpgsqlConnection connection;

        public string Name { get; private set; }

        public Table(NpgsqlConnection connection, string name)
        {
            this.connection = connection;
            Name = name;
        }
    }
}