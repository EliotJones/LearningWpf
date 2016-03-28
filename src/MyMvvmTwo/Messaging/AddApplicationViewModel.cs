namespace MyMvvmTwo.Messaging
{
    using System;
    using ViewModel;

    public class AddApplicationViewModel<T> : AddApplicationViewModel where T : ViewModelBase
    {
        public AddApplicationViewModel() : base(typeof(T))
        {
        }
    }

    public class AddApplicationViewModel
    {
        public Type ViewModelType { get; private set; }

        public AddApplicationViewModel(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
