using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {

        }
        public SavingsAccount(string name)
        {
            this.Name = name;
            this._balance = 0;
        }
        public SavingsAccount(string name, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }
        public override double AddInterest()
        {
            if (this._balance > 50000 && this._balance < 100000)
            {
                return this.Balance * 0.02;
            }
            else if (this._balance > 100000)
            {
                return this.Balance * 0.03;
            }
            else
            {
                return this.Balance * 0.01;
            }
        }

        public override string AccountType
        {
            get
            {
                return "Savings Account";
            }
        }
    }
}
