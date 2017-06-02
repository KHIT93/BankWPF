using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BankClassLib
{
    [DataContract]
    [KnownType(typeof(Account))]
    public class SalaryAccount : Account
    {
        public SalaryAccount(string name, int accountNumber)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = 0;
            this.accountType = AccountType.SalaryAccount;
            this.transactions = new List<Transaction>();
        }
        public SalaryAccount(string name, int accountNumber, double balance)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = AccountType.SalaryAccount;
            this.transactions = new List<Transaction>();
        }
        public override void AddInterest()
        {
            this.Balance *= 1.005;
        }
    }
}
