using System;
using System.Windows.Controls;
using System.Windows.Input;
using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;

namespace Inspector.GUI.Views
{
    internal partial class InitialDataTypingView : UserControl
    {
        private readonly IFinancialManager _finMgr;
        private readonly IViewHost _viewHost;

        public InitialDataTypingView(IFinancialManager finMgr, IViewHost viewHost)
        {
            InitializeComponent();

            _finMgr = finMgr;
            _viewHost = viewHost;
        }

        private void DecimalTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var finIndex = new FinIndex();

            finIndex.ProductVolume = ProductVolumeTextBox.Text.D();
            finIndex.Profit = ProfitTextBox.Text.D();
            finIndex.Revenue = RevenueTextBox.Text.D();
            finIndex.OrgId = _viewHost.OrgId;
            finIndex.StartDate = StartDatePicker.SelectedDate.Value;
            finIndex.EndDate = EndDatePicker.SelectedDate.Value;

            _finMgr.AddFinIndex(finIndex);
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
