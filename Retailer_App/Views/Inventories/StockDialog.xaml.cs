using System.Windows;
using System.Windows.Controls;
using Retailer_App.ViewModels;
using Retailer_App.Models;

namespace Retailer_App.Views.Inventories
{
    /// <summary>
    /// Interaction logic for StockDialog.xaml
    /// </summary>
    public partial class StockDialog : UserControl
    {
        public static string InsertType;
        public static int InsertQty;
        public static string ExpDate;
        public static string InsertDesc;
        public StockDialog()
        {
            InitializeComponent();
            vm = new InventorylogViewModel();
            vm.OnCallBack += ResetComponent;
            DataContext = vm;
            ResetComponent();
        }
        private InventorylogViewModel vm;

        private void ResetComponent()
        {
            ListBox.IsEnabled = false;
            TxtStock.IsEnabled = false;
            TxtExp.IsEnabled = false;
            BtnUpdate.Visibility = Visibility.Visible;
            BtnOut.Visibility = Visibility.Hidden;
            BtnIn.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;

            vm.Model = new Inventorylog();
        }

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnUpdate.Visibility = Visibility.Visible;
            BtnIn.Visibility = Visibility.Hidden;
            BtnOut.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnIn.Visibility = Visibility.Visible;
            BtnOut.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Visible;
        }
        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            ListBox.IsEnabled = true;
            TxtStock.IsEnabled = true;
            TxtExp.IsEnabled = true;

            InsertType = "OUT";
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Visible;
            BtnIn.Visibility = Visibility.Hidden;
            BtnOut.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
        }
        private void BtnIn_Click(object sender, RoutedEventArgs e)
        {
            ListBox.IsEnabled = true;
            TxtStock.IsEnabled = true;
            TxtExp.IsEnabled = true;

            InsertType = "IN";
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Visible;
            BtnIn.Visibility = Visibility.Hidden;
            BtnOut.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            BtnReset.Visibility = Visibility.Visible;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Dashboard.PnlContent.Children.Clear();
        }

        private void ChkStatus_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            int valueQty;
            if (int.TryParse(TxtStock.Text, out valueQty))
            {
                InsertQty  = valueQty;
            }
        }

        private void TxtExp_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExpDate = TxtExp.Text;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            InsertDesc = TxtExp.Text;
        }
    }
}
