namespace MyMvvmTwo.ViewModel.ServerTree
{
    using System.Linq;
    using MyMvvm.Model;

    public class ServerViewModel : TreeViewItemViewModel
    {
        public string Name { get; set; }

        public string Port { get; set; }

        public ServerViewModel(ConnectionProvider connectionProvider) : base(null)
        {
            children = connectionProvider.GetDatabases()
                .Select(d => new DatabaseViewModel(this, d)).Cast<TreeViewItemViewModel>().ToList();
            Name = connectionProvider.ServerName;
        }
    }

    public class DatabaseViewModel : TreeViewItemViewModel
    {
        public string Name { get; set; }
        
        public DatabaseViewModel(TreeViewItemViewModel parent, Database database) : base(parent)
        {
            Name = database.Name;
            children = database.GetTables()
                .Select(t => new TableViewModel(this, t)).Cast<TreeViewItemViewModel>().ToList();
        }
    }

    public class TableViewModel : TreeViewItemViewModel
    {
        public string Name { get; set; }

        public TableViewModel(TreeViewItemViewModel parent, Table table) : base(parent)
        {
            Name = table.Name;
        }
    }
}
