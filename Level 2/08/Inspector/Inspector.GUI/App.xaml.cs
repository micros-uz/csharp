using Inspector.BLL;
using Inspector.Domain.Ioc;
using System;
using System.Windows;

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
    }
}
