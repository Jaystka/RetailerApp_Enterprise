using System.Windows;
using Retailer_App.ViewModels;


namespace Retailer_App.Views.Home
{
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();
            vm = new UserViewModel();
            vm.OnCallBack += Close;
            DataContext = vm;
        }

        private readonly UserViewModel vm;

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            vm.Model.Keypass = TxtPass.Password;
        }
    }
}
