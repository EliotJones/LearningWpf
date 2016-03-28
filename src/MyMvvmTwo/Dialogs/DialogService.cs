namespace MyMvvmTwo.Dialogs
{
    using System.Windows;

    public class DialogService : IDialogService
    {
        public bool? ShowDialog(string title, DialogViewModel viewModel, Window owner = null)
        {
            var dialog = new DialogWindow(viewModel)
            {
                Title = title,
                Owner = owner ?? Application.Current.MainWindow
            };

            return dialog.ShowDialog();
        }
    }
}