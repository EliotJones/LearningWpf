namespace MyMvvmTwo.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Caliburn.Light;
    using Menu;
    using Messaging;
    using Ninject;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IKernel kernel;
        private ObservableCollection<ViewModelBase> viewModels;
        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if(viewModels == null) viewModels = new ObservableCollection<ViewModelBase>();

                return viewModels;
            }
        }

        public MainWindowViewModel(MenuViewModel menuViewModel, IEventAggregator eventAggregator, IKernel kernel)
        {
            this.kernel = kernel;
            eventAggregator.Subscribe<MainWindowViewModel, AddApplicationViewModel>(this, (_, vm) => AddViewModel(vm));
            viewModels = new ObservableCollection<ViewModelBase>
            {
                menuViewModel
            };
        }

        private void AddViewModel(AddApplicationViewModel addViewModel)
        {
            viewModels.Add(kernel.Get(addViewModel.ViewModelType) as ViewModelBase);
        }
    }
}
