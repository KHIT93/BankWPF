using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using BankWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class CalculateInterestsViewModel : BaseViewModel
    {

        public CalculateInterestsViewModel()
        {
            this.CalculateInterestsButtonCommand = new DelegateCommand(CalculateInterestsClick, CanCalculateInterests);
        }
        public bool ComboBoxEnabled
        {
            get
            {
                return this.SelectedOption == "Single";
            }
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

        protected Account selectedAccount;
        public Account SelectedAccount
        {
            get
            {
                return this.selectedAccount;
            }
            set
            {
                this.selectedAccount = value;
                RaisePropertyChanged("SelectedAccount");
            }
        }

        protected string selectedOption;
        public string SelectedOption
        {
            get
            {
                return this.selectedOption;
            }
            set
            {
                this.selectedOption = value;
                RaisePropertyChanged("SelectedOption");
                RaisePropertyChanged("ComboBoxEnabled");
            }
        }

        public ICommand CalculateInterestsButtonCommand { get; protected set; }

        protected bool calculating = false;
        public bool Calculating
        {
            get
            {
                return this.calculating;
            }
            set
            {
                this.calculating = value;
                RaisePropertyChanged("Calculating");
            }
        }
        public bool CanCalculateInterests(object parameter)
        {
            if(this.calculating == false)
            {
                if (this.SelectedOption == "All")
                {
                    return true;
                }
                else if (this.SelectedOption == "Single")
                {
                    return this.SelectedAccount != null;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async void CalculateInterestsClick(object parameter)
        {
            this.Calculating = true;
            if(this.SelectedOption == "All")
            {
                MessageBox.Show(await Task.Run(() => BankDataService.Instance.AddInterest()), "Interest calculation");
            }
            else if(this.SelectedOption == "Single")
            {
                MessageBox.Show(await Task.Run(() => BankDataService.Instance.AddInterest(this.SelectedAccount)), "Interest calculation");
            }
            this.Calculating = false;

            ((Window)parameter).DialogResult = true;
        }
    }
}
