using Bank.Data.Context;
using Bank.Data.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using Bank.Data.Services;

namespace BankWPF.ViewModels
{
    public class AccountMainViewModel : BaseViewModel
    {
        protected ObservableCollection<Account> _accounts;
        protected Account _selected;
        public AccountMainViewModel()
        {
            
        }

        public void CollectData()
        {
            ObservableCollection<Account> collection = new ObservableCollection<Account>();
            using (var context = new BankDatabaseContext())
            {
                foreach (Account account in context.Accounts.ToList())
                {
                    collection.Add(account);
                }
            }
            this.Accounts = collection;
        }

        public async Task CollectDataAsync()
        {
            await Task.Run(() =>
            {
                ObservableCollection<Account> collection = new ObservableCollection<Account>();
                using (var context = new BankDatabaseContext())
                {
                    foreach (Account account in context.Accounts.ToList())
                    {
                        collection.Add(account);
                    }
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
    }
}
