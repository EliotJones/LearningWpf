namespace MyMvvmTwo.ViewModel.Menu
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MenuItemViewModel : ViewModelBase
    {
        public virtual string Text { get; }

        public virtual ICommand Command { get; }

        protected IList<MenuItemViewModel> MenuItems = new List<MenuItemViewModel>();

        public virtual ObservableCollection<MenuItemViewModel> ChildMenuItems => new ObservableCollection<MenuItemViewModel>(MenuItems);

        public MenuItemViewModel()
        {
        }

        public MenuItemViewModel(string text, ICommand command = null, IEnumerable<MenuItemViewModel> menuItems = null)
        {
            Text = text;
            Command = command;
            if (menuItems != null)
            {
                MenuItems = menuItems.ToList();
            }
        }
    }
}
