namespace MyMvvmTwo.ViewModel.Menu
{
    using System.Collections.Generic;
    using System.Windows;

    public class FileMenuViewModel : MenuItemViewModel
    {
        public override string Text { get; } = "_File";

        public FileMenuViewModel(ConnectMenuViewModel connectMenuViewModel)
        {
            MenuItems = new List<MenuItemViewModel>
            {
                new MenuItemViewModel("_Save"),
                connectMenuViewModel,
                new MenuItemViewModel("_Exit", new RelayCommand(o => Application.Current.Shutdown()))
            };
        }
    }
}
