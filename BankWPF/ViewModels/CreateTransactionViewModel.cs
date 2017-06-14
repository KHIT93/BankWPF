using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class CreateTransactionViewModel : BaseViewModel
    {
        private bool _customerEditable = true;
        private bool _accountEditable = true;
        protected Customer _customer;
        public ICommand CreateNewTransactionButtonCommand { get; protected set; }

        public CreateTransactionViewModel()
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(Save, CanSave);
        }
        public CreateTransactionViewModel(Customer customer)
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(Save, CanSave);
            this.Customer = customer;
            this.CustomerEditable = false;
        }

        public CreateTransactionViewModel(Customer customer, Account account)
        {
            this.CreateNewTransactionButtonCommand = new DelegateCommand(Save, CanSave);
            this.Customer = customer;
            this.CustomerEditable = false;
            this.Account = account;
            this.AccountEditable = false;
        }

        public Customer Customer
        {
            get
            {
                return this._customer;
            }
            set
            {
                this._customer = value;
                RaisePropertyChanged("Customer");
                RaisePropertyChanged("Accounts");
            }
        }
        public Account Account { get; set; }
        public virtual double Amount { get; set; }
        public string Description { get; set; }

        public bool CustomerEditable
        {
            get
            {
                return this._customerEditable;
            }
            protected set
            {
                this._customerEditable = value;
                RaisePropertyChanged("CustomerEditable");
            }
        }
        public bool AccountEditable
        {
            get
            {
                return this._accountEditable;
            }
            protected set
            {
                this._accountEditable = value;
                RaisePropertyChanged("AccountEditable");
            }
        }

        public void Save()
        {
            BankDataService.Instance.Transaction(this.Amount, this.Account.AccountId, this.Description);
        }

        public void Save(object parameter)
        {
            this.Save();
            ((Window)parameter).DialogResult = true;
        }

        public bool CanSave(object parameter)
        {
            return (this.Account != null && this.Amount > 0 && String.IsNullOrEmpty(this.Description));
        }

        public ICollection<Customer> Customers
        {
            get
            {
                return BankDataService.Instance.GetCustomers();
            }
        }

        public ICollection<Account> Accounts
        {
            get
            {
                return (this.Customer != null) ? BankDataService.Instance.GetCustomer(this.Customer.Id, true).Accounts : null;
            }
        }
    }
}
