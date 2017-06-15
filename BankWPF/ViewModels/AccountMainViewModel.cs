using Bank.Data.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using Bank.Data.Services;
using BankWPF.Commands;
using BankWPF.Views;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class AccountMainViewModel : BaseViewModel
    {
        protected ObservableCollection<Account> _accounts;
        protected Account _selected;
        public ICommand CreateNewAccountButtonCommand { get; set; }
        public ICommand ShowAccountHistoryButtonCommand { get; set; }
        public ICommand DeleteAccountButtonCommand { get; set; }
        public AccountMainViewModel()
        {
            this.CreateNewAccountButtonCommand = new DelegateCommand(CreateNewAccountButtonClick, CanCreateNewAccount);
            this.ShowAccountHistoryButtonCommand = new DelegateCommand(ShowAccountHistoryButtonClick, AccountSelected);
            this.DeleteAccountButtonCommand = new DelegateCommand(DeleteAccountButtonClick, AccountSelected);
        }

        private bool CanCreateNewAccount(object arg)
        {
            return true;
        }

        public void CollectData()
        {
            ObservableCollection<Account> collection = new ObservableCollection<Account>();
            foreach (Account account in BankDataService.Instance.GetAccounts())
            {
                collection.Add(account);
            }
            this.Accounts = collection;
        }

        public async Task CollectDataAsync()
        {
            await Task.Run(() =>
            {
                ObservableCollection<Account> collection = new ObservableCollection<Account>();
                foreach (Account account in BankDataService.Instance.GetAccounts())
                {
                    collection.Add(account);
                }
                this.Accounts = collection;
            });
        }

        protected ObservableCollection<Account> accounts;
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
            protected set
            {
                this.accounts = value;
                RaisePropertyChanged("Accounts");
            }
        }

        public Account SelectedAccount
        {
            get
            {
                return this._selected;
            }
            set
            {
                this._selected = value;
                RaisePropertyChanged("SelectedAccount");
                RaisePropertyChanged("AccountIsSelected");
            }
        }

        public void DeleteAccount()
        {
            BankDataService.Instance.DeleteAccount(this.SelectedAccount.AccountId);
        }

        public bool AccountIsSelected
        {
            get
            {
                return this._selected != null;
            }
        }

        private bool AccountSelected(object parameter)
        {
            return this.AccountIsSelected;
        }

        private void CreateNewAccountButtonClick(object parameter)
        {
            if ((new CreateAccountWindow()).ShowDialog() == true)
            {
                Task.Run(() => this.CollectDataAsync());
            }
        }

        private void ShowAccountHistoryButtonClick(object parameter)
        {
            (new ShowAccountDetailsWindow
                (
                    new AccountDetailsViewModel
                    (
                        BankDataService.Instance.GetAccount
                        (
                            this.SelectedAccount.AccountId, true
                        )
                    )
                )
            ).Show();
        }

        private void DeleteAccountButtonClick(object parameter)
        {
            if (MessageBox.Show($"Are you sure that you want to delete {this.SelectedAccount.Name}", "Delete account", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.DeleteAccount();
                Task.Run(() => this.CollectDataAsync());
            }
        }
    }
}
