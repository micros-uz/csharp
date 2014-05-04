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
        public MainWindow()
        {
            InitializeComponent();

            var root = new TreeViewItem();
            root.Header = "Root";
            MainTreeView.Items.Add(root);
            var child = new TreeViewItem();
            child.Header = "Root 2";
            root.Items.Add(child);
            child = new TreeViewItem();
            child.Header = "Root 3";
            root.Items.Add(child);
            child = new TreeViewItem();
            child.Header = "Root 4";
            root.Items.Add(child);            
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow(this).ShowDialog();
        }
    }
}
