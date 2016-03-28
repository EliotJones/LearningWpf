namespace MyMvvmTwo.Startup
{
    using System.Windows.Controls;
    using Caliburn.Light;
    using Dialogs;
    using MyMvvm.Model;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using ViewModel;

    internal class Bootstrapper
    {
        public static IKernel Bootstrap()
        {
            var container = new StandardKernel();

            // Bind views.
            container.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .InheritedFrom<ContentControl>()
                    .BindToSelf());

            container.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .InheritedFrom<ViewModelBase>()
                    .BindToSelf());

            container.Bind<ConnectionProvider>().ToSelf().InSingletonScope();
            container.Bind<IDialogService>().To<DialogService>();
            container.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            return container;
        }
    }
}
