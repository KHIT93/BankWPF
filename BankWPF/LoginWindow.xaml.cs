using Bank.Data.Models;
using Bank.Security;
using BankWPF.ViewModels;
using System.Windows;
using System;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        protected LoginViewModel vm;
        public LoginWindow()
        {
            try
            {
                InitializeComponent();
                this.vm = new LoginViewModel();
                this.DataContext = vm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.vm.Password = this.PasswordTextBox.Password;
        }
    }
}
