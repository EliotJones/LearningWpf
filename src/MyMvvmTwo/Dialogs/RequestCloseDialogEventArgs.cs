namespace MyMvvmTwo.Dialogs
{
    using System;

    public class RequestCloseDialogEventArgs : EventArgs
    {
        public bool DialogResult { get; }

        public RequestCloseDialogEventArgs(bool dialogResult)
        {
            DialogResult = dialogResult;
        }
    }
}