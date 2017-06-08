using Bank.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class Overdraft : Account
    {
        public Overdraft(string name, int accountNumber)
        {
            this.Name = name;
            this._balance= 0;
        }
        public Overdraft(string name, int accountNumber, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }

        public override double Balance
        {
            get { return this._balance; }
            set
            {
                this._balance = value;
                if ((this._balance) < 0)
                {
                    throw new NegativeBalanceException(string.Format("Warning!\nPlease note that the account balance for account number {0} is negative.\nThe current balance is {1:c}", this.AccountId, this._balance));
                }
            }
        }
        public override void AddInterest()
        {
            this._balance *= (this._balance < 0) ? 1.05 : 1.005;
        }
    }
}
