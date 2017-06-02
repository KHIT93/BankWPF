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
    public class Overdraft : Account
    {
        public Overdraft(string name, int accountNumber)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = 0;
            this.accountType = AccountType.Overdraft;
            this.transactions = new List<Transaction>();
        }
        public Overdraft(string name, int accountNumber, double balance)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
            this.accountType = AccountType.Overdraft;
            this.transactions = new List<Transaction>();
        }

        [DataMember]
        public override double Balance
        {
            get { return balance; }
            set
            {
                this.transactions.Add(new Transaction(this.AccountNumber, (value - this.balance)));
                if ((balance = value) < 0)
                {
                    throw new NegativeBalanceException(string.Format("Warning!\nPlease note that the account balance for account number {0} is negative.\nThe current balance is {1:c}", this.accountNumber, this.balance));
                }
            }
        }
        public override void AddInterest()
        {
            this.Balance *= (this.balance < 0) ? 1.05 : 1.005;
        }
    }
}
