using System.Windows;

namespace MyMvvmTwo
{
    using ViewModel;
    
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
