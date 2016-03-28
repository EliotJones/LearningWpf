namespace MyMvvmTwo.Dialogs
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ViewModel;

    public class DialogViewModel : ViewModelBase
    {
        private readonly List<ViewModelBase> viewModelsList;
        public virtual ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                return new ObservableCollection<ViewModelBase>(viewModelsList);
            }
        }

        public DialogViewModel()
        {
        }

        public DialogViewModel(IEnumerable<ViewModelBase> viewModels)
        {
            if (viewModels != null)
            {
                viewModelsList = new List<ViewModelBase>(viewModels);
            }
        }

        private bool? dialogResult;

        public bool? DialogResult
        {
            get { return dialogResult; }
            set { dialogResult = value; OnPropertyChanged(); }
        }
    }
}
