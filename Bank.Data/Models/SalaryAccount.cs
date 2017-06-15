using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class SalaryAccount : Account
    {
        public SalaryAccount()
        {

        }
        public SalaryAccount(string name)
        {
            this.Name = name;
            this._balance = 0;
        }
        public SalaryAccount(string name, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }
        public override double AddInterest()
        {
            return this.Balance * 0.005;
        }

        public override string AccountType
        {
            get
            {
                return "Salary Account";
            }
        }
    }
}
