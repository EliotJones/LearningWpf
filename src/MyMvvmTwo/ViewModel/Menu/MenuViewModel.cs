namespace MyMvvmTwo.ViewModel.Menu
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(FileMenuViewModel fileMenuViewModel)
        {
            menuItems = new List<MenuItemViewModel>
            {
                fileMenuViewModel
            };
        }

        private readonly List<MenuItemViewModel> menuItems;

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get { return new ObservableCollection<MenuItemViewModel>(menuItems); }
        }
    }
}
