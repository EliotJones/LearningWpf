namespace MyMvvmTwo.Dialogs
{
    using System.Windows;

    public interface IDialogService
    {
        bool? ShowDialog(string title, DialogViewModel viewModel, Window owner = null);
    }
}
