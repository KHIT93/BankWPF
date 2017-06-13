using Bank.Data.Services;
using BankWPF.ViewModels;
using BankWPF.Views;
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

namespace BankWPF.UserControls
{
    /// <summary>
    /// Interaction logic for CustomersMainWindow.xaml
    /// </summary>
    public partial class CustomersMainWindow : UserControl
    {
        protected CustomersMainViewModel vm;
        public CustomersMainWindow()
        {
            InitializeComponent();
            this.vm = new CustomersMainViewModel();
            this.DataContext = this.vm;
            Task.Run(() => (this.vm.CollectDataAsync()));
        }

        private void CreateNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if((new CreateCustomerWindow()).ShowDialog() == true)
            {
                Task.Run(() => (this.vm.CollectDataAsync()));
            }
        }

        private void ShowCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            (new ShowCustomerWindow
                (
                    new ShowCustomerViewModel
                    (
                        BankDataService.Instance.GetCustomer
                        (
                            this.vm.SelectedCustomer.Id, true
                        )
                    )
                )
            ).Show();
        }
    }
}
