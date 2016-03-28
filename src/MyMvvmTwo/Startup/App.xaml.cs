namespace MyMvvmTwo.Startup
{
    using System.Windows;
    using Ninject;
    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = Bootstrapper.Bootstrap();
            
            var mainWindow = container.Get<MainWindow>();

            mainWindow.Show();
        }
    }
}
