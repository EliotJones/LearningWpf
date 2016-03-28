namespace MyMvvmTwo.ViewModel.ServerTree
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TreeViewItemViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get
            {
                return new ObservableCollection<TreeViewItemViewModel>(children);
            }
        }

        protected List<TreeViewItemViewModel> children = new List<TreeViewItemViewModel>();
        public bool IsExpanded { get; set; } = true;
        public bool IsSelected { get; set; }
        public TreeViewItemViewModel Parent { get; set; }

        public TreeViewItemViewModel(TreeViewItemViewModel parent)
        {
            Parent = parent;
        }
    }
}