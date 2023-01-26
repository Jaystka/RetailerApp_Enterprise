using System.Windows;
using System.Windows.Controls;
using Retailer_App.ViewModels;

namespace Retailer_App.Views.Inventories
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl
    {
        public EditorView()
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

        }
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            //ResetComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Dashboard.PnlContent.Children.Clear();
            App.Dashboard.PnlContent.Children.Add(new InventoriesView());
        }

        private void FontsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
