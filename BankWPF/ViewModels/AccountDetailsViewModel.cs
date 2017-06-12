using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class AccountDetailsViewModel : BaseViewModel
    {
        private Account model;
        public AccountDetailsViewModel(Account model)
        {
            this.model = model;
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

        #endregion
    }
}
