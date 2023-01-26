using System.Windows;
using System.Windows.Controls;
using Retailer_App.ViewModels;

namespace Retailer_App.Views.Home
{
    /// <summary>
    /// Interaction logic for RulesDialog.xaml
    /// </summary>
    public partial class RulesDialog : Window
    {
       // private static string name;
        public RulesDialog()
        {
            InitializeComponent();
            vm = new UserRuleViewModel();
            vm.OnCallBack += ResetComponent;
            DataContext = vm;
            ResetComponent();
        }

        private UserRuleViewModel vm;

        private void ResetComponent()
        {

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChkUsersView_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkInventories_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkInventory_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkStock_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkProduct_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkBackup_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }
    }
}
