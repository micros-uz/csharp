using Inspector.Domain.Interfaces;
using Inspector.Domain.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inspector.GUI
{
    public partial class MainWindow : Window
    {
        private ICatalogManager _catMgr;

        public MainWindow()
        {
            InitializeComponent();

            var root = new TreeViewItem();
            root.Header = "Tree";

            var child = new TreeViewItem();
            child.Header = "Initial Data Typing";
            root.Items.Add(child);

            child = new TreeViewItem();
            child.Header = "Descriptions";
            root.Items.Add(child);

            MainTreeView.Items.Add(root);

            root.ExpandSubtree();
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow(this).ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _catMgr = IoC.Get<ICatalogManager>();

            var areas = _catMgr.GetAreas();

            foreach (var item in areas)
            {
                AreaComboBox.Items.Add(item.Name);
            }
        }

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
