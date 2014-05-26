using Inspector.BLL;
using Inspector.Domain.Ioc;
using Inspector.Domain.Models;
using Inspector.GUI.Forms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Inspector.GUI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {/*
            var list = new Area[]
            {
                new Area{Name = "A", SOATO = "17"},
                new Area{Name = "B", SOATO = "175"},
                new Area{Name = "C", SOATO = "18"},
                new Area{Name = "A", SOATO = "17"},
            };

            var list2 = list.Where(x => x.Name != "A").Select(x => x.SOATO);
            foreach (var item in list2)
            {
                Debug.WriteLine(item);
            }

            Type t = typeof(Area);
            var pe = System.Linq.Expressions.Expression.Parameter(t);
            var mi = t.GetField("Name");
            var me = System.Linq.Expressions.Expression.MakeMemberAccess(pe, mi);
            var c = System.Linq.Expressions.Expression.Constant("A", typeof(string));
            var be = System.Linq.Expressions.Expression.NotEqual(me, c);
            var efab = System.Linq.Expressions.Expression<Func<Area, bool>>
                .Lambda<Func<Area, bool>>(be, pe);

            */

            Bootstrapper.Init();

            IoC.Register<MainWindow, MainWindow>(IoCMode.Singleton);
            IoC.Register<InitialDataTypingForm, InitialDataTypingForm>();
            IoC.Register<DescriptionsForm, DescriptionsForm>();
            IoC.Register<IFormHost, MainWindow>();

            IoC.Get<MainWindow>().Show();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
