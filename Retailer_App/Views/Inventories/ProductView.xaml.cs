using System.Windows;
using System.Windows.Controls;
using Retailer_App.ViewModels;
using Retailer_App.Models;

namespace Retailer_App.Views.Inventories
{
    public partial class ProductView : UserControl
    {
        public ProductView()
        {

                InitializeComponent();
                vm = new ProductViewModel();
                vm.OnCallBack += ResetComponent;
                DataContext = vm;
                ResetComponent();
            
        }

        private ProductViewModel vm;

        private void ResetComponent()
        {
            TxtCode.IsReadOnly = true;
            BtnNew.Visibility = Visibility.Visible;
            BtnEdit.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;

            TxtProduct.IsEnabled = false;
            TxtCode.IsEnabled = false;
            ChkStatus.IsEnabled = false;
            vm.Model = new Product();
        }

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnNew.Visibility = Visibility.Hidden;
            BtnEdit.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Visible;
            BtnInsert.Visibility = Visibility.Hidden;

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            BtnInsert.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
            TxtProduct.IsEnabled = true;
            TxtCode.IsEnabled = false;
            ChkStatus.IsEnabled = true;
            vm.Model = new Product();
            TxtProduct.Focus();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdate.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Hidden;
            TxtProduct.IsEnabled = true;
            TxtCode.IsEnabled = false;
            ChkStatus.IsEnabled = true;
            TxtProduct.Focus();
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdate.Visibility = Visibility.Visible;
            TxtProduct.IsEnabled = true;
            TxtCode.IsEnabled = false;
            ChkStatus.IsEnabled = true;
            TxtProduct.Focus();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
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
    }
}
