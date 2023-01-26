
using System.Windows;
using System.Windows.Controls;
using Retailer_App.ViewModels;
using Retailer_App.Models;


namespace Retailer_App.Views.Home
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public static string UserUid;
        public UsersView()
        {

            InitializeComponent();
            vm = new UserViewModel();
            vm.OnCallBack += ResetComponent;
            DataContext = vm;
            ResetComponent();
        }

        private UserViewModel vm;

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnNew.Visibility = Visibility.Hidden;
            BtnEdit.Visibility = Visibility.Visible;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnMenu.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Visible;

        }

        private void ResetComponent()
        {
            TxtUid.IsReadOnly = true;

            BtnNew.Visibility = Visibility.Visible;
            BtnEdit.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
            BtnMenu.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
            LblUid.Visibility = Visibility.Hidden;
            TxtUid.Visibility = Visibility.Hidden;

            TxtName.IsEnabled = false;
            TxtUser.IsEnabled = false;
            TxtPassword.IsEnabled = false;
            ChkStatus.IsEnabled = false;

            vm.Model = new User();
            BtnNew.Focus();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            BtnNew.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
            BtnInsert.Visibility = Visibility.Visible;
            TxtName.IsEnabled = true;
            TxtUser.IsEnabled = true;
            TxtPassword.IsEnabled = true;
            ChkStatus.IsEnabled = true;
            vm.Model = new User();
            vm.IsChecked = true;
            TxtName.Focus();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            BtnEdit.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Hidden;
            BtnMenu.Visibility = Visibility.Visible;
            TxtName.IsEnabled = true;
            TxtUser.IsEnabled = true;
            TxtPassword.IsEnabled = true;
            ChkStatus.IsEnabled = true;
            LblUid.Visibility = Visibility.Visible;
            TxtUid.Visibility = Visibility.Visible;
            TxtName.Focus();
        }


        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserUid = vm.Model.Uid;
            RulesDialog f = new RulesDialog();
            f.Show();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Dashboard.PnlContent.Children.Clear();
        }

        private void TblData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
