using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class CreateWithdrawTransactionViewModel : CreateTransactionViewModel
    {

        public CreateWithdrawTransactionViewModel()
        {

        }
        public CreateWithdrawTransactionViewModel(Customer customer)
        {
            this.Customer = customer;
            this.CustomerEditable = false;
        }

        public CreateWithdrawTransactionViewModel(Customer customer, Account account)
        {
            this.Customer = customer;
            this.CustomerEditable = false;
            this.Account = account;
            this.AccountEditable = false;
        }

        protected double _amount;
        public override double Amount
        {
            get
            {
                return -this._amount;
            }
            set
            {
                this._amount = value;
            }
        }
    }
}
