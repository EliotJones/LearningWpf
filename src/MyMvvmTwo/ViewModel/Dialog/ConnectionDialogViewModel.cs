namespace MyMvvmTwo.ViewModel.Dialog
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;
    using Caliburn.Light;
    using Dialogs;
    using Messaging;
    using MyMvvm.Model;

    public class ConnectionDialogViewModel : DialogViewModel, IDataErrorInfo
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ConnectionProvider connectionProvider;

        private string host;
        public string Host
        {
            get { return host; }
            set { host = value; OnPropertyChanged(); }
        }

        private string username = "postgres";
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private int port = 5432;

        public int Port
        {
            get { return port; }
            set { port = value; OnPropertyChanged(); }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private bool useIntegratedSecurity;
        public bool UseIntegratedSecurity
        {
            get { return useIntegratedSecurity; }
            set { useIntegratedSecurity = value; OnPropertyChanged(); }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; OnPropertyChanged(); }
        }

        public IDelegateCommand ConnectCommand { get; private set; }

        public ConnectionDialogViewModel(IEventAggregator eventAggregator, ConnectionProvider connectionProvider)
        {
            this.eventAggregator = eventAggregator;
            this.connectionProvider = connectionProvider;

            ConnectCommand =
                DelegateCommand.NoParameter()
                    .OnCanExecute(() => CanAttemptConnect)
                    .OnExecute(() => AttemptConnect())
                    .Observe(this, nameof(Host), nameof(Password), nameof(Port))
                    .Build();
        }

        private bool CanAttemptConnect
        {
            get { return this.IsValid; }
        }

        public bool IsValid
        {
            get
            {
                foreach (var result in this.GetType().GetProperties().Select(p => p.Name))
                {
                    if (this[result] != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void AttemptConnect()
        {
            if (connectionProvider.TestConnection(Username, Password, Host, Port))
            {
                eventAggregator.Publish(new AddApplicationViewModel<ServerTreeViewModel>());
                DialogResult = true;
            }
            else
            {
                ErrorMessage = "Error on connecting with these details";
            }
        }

        public string this[string propertyName]
        {
            get
            {
                CommandManager.InvalidateRequerySuggested();

                switch (propertyName)
                {
                    case nameof(Username):
                        return ValidateUsername();
                    case nameof(Password):
                        return ValidatePassword();
                    case nameof(Host):
                        return ValidateHost();
                    case nameof(Port):
                        return ValidatePort();
                    default:
                        return null;
                }
            }
        }

        public string Error { get; }

        private string ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(Username) && !UseIntegratedSecurity)
            {
                return "You must provide a username where you are not using integrated security.";
            }
            return null;
        }

        private string ValidatePort()
        {
            return null;
        }

        private string ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password) && !UseIntegratedSecurity)
            {
                return "You must provide a password where you are not using integrated security.";
            }

            return null;
        }

        private string ValidateHost()
        {
            if (string.IsNullOrWhiteSpace(Host))
            {
                return "You must provide a server.";
            }

            return null;
        }

        ~ConnectionDialogViewModel()
        {
            Debug.WriteLine("Finalized connection dialog view model");
        }
    }
}
