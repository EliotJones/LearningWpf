namespace MyMvvmTwo.ViewModel.Menu
{
    using System.Windows.Input;
    using Caliburn.Light;
    using Dialog;
    using Dialogs;
    using MyMvvm.Model;
    using RelayCommand = RelayCommand;

    public class ConnectMenuViewModel : MenuItemViewModel
    {
        private readonly ConnectionProvider connectionProvider;
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;

        private void MyCommandExecute()
        {
            var result = dialogService.ShowDialog("Connect", new DialogViewModel(new[] { new ConnectionDialogViewModel(eventAggregator, connectionProvider) }));
            // connectionProvider.TestConnection("postgres", "postgres", "localhost", 5432);
        }

        private bool CanMyCommandExecute()
        {
            return !connectionProvider.HasConnection;
        }

        private RelayCommand connectCommand;

        public override ICommand Command
        {
            get
            {
                if (connectCommand == null)
                {
                    connectCommand = new RelayCommand(o => MyCommandExecute(), o => CanMyCommandExecute());
                }

                return connectCommand;
            }
        }

        public ConnectMenuViewModel(ConnectionProvider connectionProvider, IDialogService dialogService, IEventAggregator eventAggregator) : base("_Connect")
        {
            this.connectionProvider = connectionProvider;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
        }
    }
}
