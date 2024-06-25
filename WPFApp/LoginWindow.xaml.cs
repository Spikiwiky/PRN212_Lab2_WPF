using BusinessObjects;
using Services;
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
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra iAccountService không null
            if (iAccountService == null)
            {
                MessageBox.Show("Account service is not initialized.");
                return;
            }

            // Kiểm tra txtUser và txtUser.Text không null
            if (txtUser == null || string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            // Kiểm tra txtPass và txtPass.Password không null
            if (txtPass == null || string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Password is required.");
                return;
            }

            // Lấy tài khoản
            AccountMember account = iAccountService.GetAccountById(txtUser.Text);
            if (account != null && account.MemberPassword != null && account.MemberPassword.Equals(txtPass.Password) && account.MemberRole == 1)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("You are not permission!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
