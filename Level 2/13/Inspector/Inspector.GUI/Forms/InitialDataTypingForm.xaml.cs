using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;
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

namespace Inspector.GUI.Forms
{
    internal partial class InitialDataTypingForm : UserControl
    {
        private readonly IFinancialManager _finMgr;
        private readonly IFormHost _formHost;

        internal InitialDataTypingForm(IFinancialManager finMgr,
            IFormHost formHost)
        {
            InitializeComponent();

            _finMgr = finMgr;
            _formHost = formHost;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var finIndex = new FinIndex();

            finIndex.ProductVolume = ProductVolumeTextBox.Text.D();
            finIndex.Profit = ProfitTextBox.Text.D();
            finIndex.Revenue = RevenueTextBox.Text.D();
            finIndex.OrgId = _formHost.OrgId;
            finIndex.StartDate = StartDatePicker.SelectedDate.Value;
            finIndex.EndDate = EndDatePicker.SelectedDate.Value;

            _finMgr.AddFinIndex(finIndex);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete ALL organization in the selected area?",
                "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {

            }
        }

        private void DecimalTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isDigit = Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key));

            if (!isDigit && e.Key != Key.Back && e.Key != Key.Delete
                && e.Key != Key.Left && e.Key != Key.Right 
                && e.Key != Key.Home && e.Key != Key.End
                && e.Key != Key.OemPeriod && e.Key != Key.Decimal
                && e.Key != Key.NumPad0 && e.Key != Key.Tab)            
            {
                e.Handled = true;
            }
        }
    }
}
