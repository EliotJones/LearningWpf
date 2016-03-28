namespace MyMvvmTwo.Dialogs
{
    using System.Windows;
    
    public partial class DialogWindow : Window
    {
        public DialogWindow(DialogViewModel dialogViewModel)
        {
            InitializeComponent();
            this.DataContext = dialogViewModel;
        }
    }
}
