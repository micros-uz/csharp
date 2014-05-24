using Inspector.Domain.Interfaces;
using Inspector.Domain.Ioc;
using Inspector.Domain.Models;
using Inspector.GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private readonly ICatalogManager _catMgr;
        private IEnumerable<Area> _areas;

        public MainWindow(ICatalogManager catMgr)
        {
            InitializeComponent();

            _catMgr = catMgr;

            var root = new TreeViewItem();
            root.Header = "Tree";

            var child = CreateTreeViewItem("Initial Data Typing");
            child.Tag = typeof(InitialDataTypingForm);
            root.Items.Add(child);

            child = CreateTreeViewItem("Descriptions");
            child.Tag = typeof(DescriptionsForm);
            root.Items.Add(child);

            MainTreeView.Items.Add(root);

            root.ExpandSubtree();

            AreaComboBox.AddHandler(TextBoxBase.TextChangedEvent,
                new TextChangedEventHandler(ComboBox_TextChanged));
        }

        private TreeViewItem CreateTreeViewItem(string itemName)
        {
            var child = new TreeViewItem();
            child.Header = itemName;
            child.Selected += TreeViewItem_Selected;
            return child;
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            FormGrid.Children.Clear();

            var type = (Type)(sender as TreeViewItem).Tag;

            var form = (UIElement)IoC.Get(type);

            FormGrid.Children.Add(form);
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AreaComboBox.IsDropDownOpen = true;

            /*
             * http://stackoverflow.com/questions/4088744/wpf-combobox-textsearch-how-does-it-work
             * 
             * */

            var edit = (TextBox)AreaComboBox.Template
                .FindName("PART_EditableTextBox", AreaComboBox);

            if (!string.IsNullOrEmpty(edit.SelectedText))
            {
                AreaComboBox.Items.Clear();

                _areas.Where(x => x.Name.StartsWith(edit.SelectedText))
                    .ToList().ForEach(x => AreaComboBox.Items.Add(x));
            }
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow(this).ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAreas();
        }

        private void LoadAreas()
        {
            _areas = _catMgr.GetAreas();

            AreaComboBox.Items.Clear();
            _areas.ToList().ForEach(x => AreaComboBox.Items.Add(x));
        }

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selItem = AreaComboBox.SelectedItem as Area;

            if (selItem != null)
            {
                var orgs = _catMgr.GetOrgatizations(selItem.SOATO);

                OKPOComboBox.Items.Clear();

                orgs.ToList().ForEach(x => OKPOComboBox.Items.Add(x));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete ALL organization in the selected area?",
                "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {

            }
        }



        private int GetOrgId()
        {
            return 1;
        }
    }
}
