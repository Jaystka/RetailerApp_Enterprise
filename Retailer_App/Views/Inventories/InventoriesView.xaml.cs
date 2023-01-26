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
using Retailer_App.ViewModels;
using Retailer_App.Models;
using System.Globalization;
using System.Data;
using System.ComponentModel;

namespace Retailer_App.Views.Inventories
{

    public partial class InventoriesView : UserControl
    {
        public static string startDate;
        public static string endDate;
        public static string ComboBoxValue;
        public InventoriesView()
        {
            InitializeComponent();
            vm = new InventoryViewModel();
            vm.OnCallBack += ResetComponent;
            DataContext = vm;
            ResetComponent();
        }

        private InventoryViewModel vm;

        private void ResetComponent()
        {
            vm.Model = new Inventory();
        }
        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnEdit.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Visible;

        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
           
            if (ComboBoxValue != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(TblData.ItemsSource);
                view.Filter = item =>
                {
                    var log = item as Inventory;
                    if (log != null)
                        return log.Type == ComboBoxValue;
                    else
                        return false;
                };
            }
            BoxType.SelectedIndex = -1;

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.Dashboard.PnlContent.Children.Clear();
            App.Dashboard.PnlContent.Children.Add(new EditorView());
        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
            ICollectionView view = CollectionViewSource.GetDefaultView(TblData.ItemsSource);
            view.Filter = null;
            BoxType.SelectedIndex = -1;
            StartDate.SelectedDate = null;
            EndDate.SelectedDate = null;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Dashboard.PnlContent.Children.Clear();
        }

        private void FontsCombo_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TblData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SdatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDate.SelectedDate != null) {
                DateTime selectedDate = StartDate.SelectedDate.Value;
                startDate = selectedDate.ToString("yyyy/MM/dd");
            }
        }

        private void EdatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EndDate.SelectedDate != null)
            {
                DateTime selectedDate = EndDate.SelectedDate.Value;
                endDate = selectedDate.ToString("yyyy/MM/dd");
            }
        }

        private void BoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BoxType.SelectedIndex != -1) {
                ComboBoxItem selectedItem = (ComboBoxItem)BoxType.SelectedItem;
                ComboBoxValue = selectedItem.Content.ToString();
            }

        }
        //    private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //   {
        // ComboBoxItem selectedItem = (ComboBoxItem)comboBoxItem.SelectedItem;
        //      MessageBox.Show("Item yang dipilih: " + selectedItem.Content);
        //  }
    }
}
