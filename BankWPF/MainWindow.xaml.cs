using BankWPF.ViewModels;
using BankWPF.UserControls;
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
using BankWPF.Views;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("Expose.ico", UriKind.Relative));
        }

        private void ShowAccountsButton_Click(object sender, RoutedEventArgs e)
        {
            this.ContentStackPanel.Children.Clear();
            this.ContentStackPanel.Children.Add(new AccountsMainView());
        }

        private void CreateTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            (new CreateRawTransactionWindow()).ShowDialog();
        }

        private void ShowCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            this.ContentStackPanel.Children.Clear();
            this.ContentStackPanel.Children.Add(new CustomersMainWindow());
        }
    }
}
