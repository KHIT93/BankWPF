using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using BankWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class AccountDetailsViewModel : BaseViewModel
    {
        private Account model;
        public AccountDetailsViewModel(Account model)
        {
            this.model = model;
            this.DepositTransactionMenuItemCommand = new DelegateCommand(DepositTransactionMenuItemClick, CanDeposit);
            this.WithdrawTransactionMenuItemCommand = new DelegateCommand(WithdrawTransactionMenuItemClick, CanWithdraw);
        }

        public string WindowTitle
        {
            get
            {
                return $"Details for account {this.Name} owned by {this.Customer.FullName}";
            }
        }

        #region Properties
        public string Name
        {
            get
            {
                return this.model.Name;
            }
            set
            {
                this.model.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int AccountId
        {
            get
            {
                return this.model.AccountId;
            }
        }

        public double Balance
        {
            get
            {
                return this.model.Balance;
            }
            set
            {
                this.model.Balance = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.model.Customer;
            }
            set
            {
                this.model.Customer = value;
            }
        }

        public void RefreshModel()
        {
            this.model = BankDataService.Instance.GetAccount(this.AccountId, true);
            RaisePropertyChanged("Transactions");
        }

        public ICollection<Transaction> Transactions
        {
            get
            {
                return this.model.Transactions;
            }
        }

        public string AccountType
        {
            get
            {
                return this.model.AccountType;
            }
        }

        public ICommand DepositTransactionMenuItemCommand { get; private set; }
        public void DepositTransactionMenuItemClick(object parameter)
        {
            if ((new CreateTransactionWindow
                (
                    new CreateTransactionViewModel
                    (
                        this.Customer,
                        BankDataService.Instance.GetAccount(this.AccountId, false)
                    )
                )
                .ShowDialog() == true))
            {
                this.RefreshModel();
            }
        }

        public bool CanDeposit(object parameter)
        {
            return true;
        }
        public ICommand WithdrawTransactionMenuItemCommand { get; private set; }

        public void WithdrawTransactionMenuItemClick(object parameter)
        {
            if ((new CreateTransactionWindow
                (
                    new CreateWithdrawTransactionViewModel
                    (
                        this.Customer,
                        BankDataService.Instance.GetAccount(this.AccountId, false)
                    )
                )
                .ShowDialog() == true))
            {
                this.RefreshModel();
            }
        }

        public bool CanWithdraw(object parameter)
        {
            return this.model.CanWithdraw();
        }

        #endregion
    }
}
