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
    public partial class InitialDataTypingForm : UserControl
    {
        private readonly IFinancialManager _finMgr;

        public InitialDataTypingForm(IFinancialManager finMgr)
        {
            InitializeComponent();

            _finMgr = finMgr;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var finIndex = new FinIndex();

            finIndex.ProductVolume = ProductVolumeTextBox.Text.D();
            finIndex.Profit = ProfitTextBox.Text.D();
            finIndex.Revenue = RevenueTextBox.Text.D();
            //finIndex.OrgId = GetOrgId();
            finIndex.StartDate = StartDatePicker.SelectedDate.Value;
            finIndex.EndDate = EndDatePicker.SelectedDate.Value;

            _finMgr.AddFinIndex(finIndex);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
