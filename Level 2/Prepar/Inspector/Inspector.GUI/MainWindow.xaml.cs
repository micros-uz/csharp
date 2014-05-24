using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Inspector.Domain.Interfaces;
using Inspector.Domain.Ioc;
using Inspector.Domain.Models;
using Inspector.GUI.Views;

namespace Inspector.GUI
{
    public partial class MainWindow : Window, IViewHost
    {
        private readonly ICatalogManager _catMgr;
        private IEnumerable<Area> _areas;
        private readonly IFinancialManager _finMgr;

        public MainWindow(ICatalogManager catMgr, IFinancialManager finMgr)
        {
            InitializeComponent();

            _catMgr = catMgr;
            _finMgr = finMgr;

            var root = new TreeViewItem();
            root.Header = "Tree";

            var child = new TreeViewItem();
            child.Header = "Initial Data Typing";
            child.Selected += TreeViewItemSelected;
            child.Tag = typeof(InitialDataTypingView);
            root.Items.Add(child);

            child = new TreeViewItem();
            child.Header = "Descriptions";
            child.Selected += TreeViewItemSelected;
            child.Tag = typeof(DescriptionView);
            root.Items.Add(child);

            MainTreeView.Items.Add(root);

            root.ExpandSubtree();
        }

        private void TreeViewItemSelected(object sender, RoutedEventArgs e)
        {
            ViewGrid.Children.Clear();

            var view = IoC.Get((Type)((TreeViewItem)sender).Tag);

            ViewGrid.Children.Add(view as UserControl);
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

            EnableViewGrid();
        }

        private void EnableViewGrid()
        {
            ViewGrid.IsEnabled = OrgId > 0;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete ALL organization in the selected area?",
                "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {

            }
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var finIndex = new FinIndex();

        //    finIndex.ProductVolume = ProductVolumeTextBox.Text.D();
        //    finIndex.Profit = ProfitTextBox.Text.D();
        //    finIndex.Revenue = RevenueTextBox.Text.D();
        //    finIndex.OrgId = OrgId;
        //    finIndex.StartDate = StartDatePicker.SelectedDate.Value;
        //    finIndex.EndDate = EndDatePicker.SelectedDate.Value;

        //    _finMgr.AddFinIndex(finIndex);
        //}

        public int OrgId
        {
            get
            {
                var selItem = OKPOComboBox.SelectedItem as Organization;

                if (selItem != null)
                {
                    return selItem.Id;
                }

                return -1;
            }
        }

        private void OKPOComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableViewGrid();
        }

    }
}
