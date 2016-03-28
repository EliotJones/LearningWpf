namespace MyMvvmTwo.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using MyMvvm.Model;
    using ServerTree;

    public class ServerTreeViewModel : ViewModelBase
    {
        private readonly ConnectionProvider connectionProvider;


        public ServerTreeViewModel(ConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
            servers = new List<ServerViewModel> { new ServerViewModel(connectionProvider) };
        }

        private List<ServerViewModel> servers;

        public ReadOnlyCollection<ServerViewModel> Servers
        {
            get { return new ReadOnlyCollection<ServerViewModel>(servers); }
        }
    }
}
