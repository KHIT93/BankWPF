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
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name, int accountNumber)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = 0;
            this.accountType = AccountType.SavingsAccount;
            this.transactions = new List<Transaction>();
        }
        public SavingsAccount(string name, int accountNumber, double balance)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = AccountType.SavingsAccount;
            this.transactions = new List<Transaction>();
        }
        public override void AddInterest()
        {
            if (this.balance < 50000)
            {
                this.balance *= 1.01;
            }
            else if (this.balance > 50000 && this.balance < 100000)
            {
                this.balance *= 1.02;
            }
            else if (this.balance > 100000)
            {
                this.Balance *= 1.03;
            }
        }
    }
}
