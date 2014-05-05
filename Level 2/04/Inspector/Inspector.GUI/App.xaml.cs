using Inspector.BLL;
using System;
using System.Windows;

namespace Inspector.GUI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Bootstrapper.Init();
        }
    }
}
