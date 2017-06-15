using Bank.Data.Exceptions;
using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.ViewModels
{
    public class CreateWithdrawTransactionViewModel : CreateTransactionViewModel
    {

        public CreateWithdrawTransactionViewModel()
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(SaveWithdraw, CanSaveWithdraw);

        }
        public CreateWithdrawTransactionViewModel(Customer customer)
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(SaveWithdraw, CanSaveWithdraw);
            this.Customer = customer;
            this.CustomerEditable = false;
        }

        public CreateWithdrawTransactionViewModel(Customer customer, Account account)
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(SaveWithdraw, CanSaveWithdraw);
            this.Customer = customer;
            this.CustomerEditable = false;
            this.Account = account;
            this.AccountEditable = false;
        }

        public bool CanSaveWithdraw(object parameter)
        {
            return this.Account.Balance - this.Amount > 0;
            //return (this.Account != null && this.Amount > 0 && String.IsNullOrEmpty(this.Description) && (this.Account.Balance-this.Amount) > 0);
        }

        protected double _amount;
        public override double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
                RaisePropertyChanged("Amount");
            }
        }

        public void SaveWithdraw()
        {
            BankDataService.Instance.Transaction(-this.Amount, this.Account.AccountId, this.Description);
        }

        public void SaveWithdraw(object parameter)
        {
            try
            {
                this.SaveWithdraw();
                ((Window)parameter).DialogResult = true;
            }
            catch (NegativeBalanceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
