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
    /// Interaction logic for AccountsMainView.xaml
    /// </summary>
    public partial class AccountsMainView : UserControl
    {
        protected AccountMainViewModel vm;
        public AccountsMainView()
        {
            InitializeComponent();
            this.vm = new AccountMainViewModel();
            this.DataContext = this.vm;
            Task.Run(() => (this.vm.CollectDataAsync()));
        }

        private void AccountsListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(this.vm.SelectedAccount != null)
            {
                DragDrop.DoDragDrop(this.AccountsListView, this.vm.SelectedAccount.AccountId.ToString(), DragDropEffects.Copy);
                this.vm.SelectedAccount = null;
            }
        }
    }
}
