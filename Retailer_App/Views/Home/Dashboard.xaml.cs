using System;
using System.Windows;
using Retailer_App.Views.Inventories;

namespace Retailer_App.Views.Home
{
    public partial class Dashboard : Window
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void MnUsers_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new UsersView());
        }

        private void MnRelogin_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            LoginDialog f = new LoginDialog();
            f.Show();
        }
        private void MnBackup_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new UsersView());
        }
        private void MnExit_Click(Object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MnInventory_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new InventoriesView());
        }

        private void VwUsersrule_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            RulesDialog f = new RulesDialog();
            f.Show();
        }
        private void MnStock_Click(Object sender, RoutedEventArgs e)
        {
           
           PnlContent.Children.Clear();
           PnlContent.Children.Add(new StockDialog());
        }
        private void MnProduct_Click(Object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new ProductView());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new InventoriesView());
        }
    }
}
