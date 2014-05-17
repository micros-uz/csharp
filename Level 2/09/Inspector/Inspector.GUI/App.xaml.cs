using Inspector.BLL;
using Inspector.Domain.Ioc;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Inspector.GUI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Bootstrapper.Init();

            IoC.Register<MainWindow, MainWindow>();

            IoC.Get<MainWindow>().Show();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
