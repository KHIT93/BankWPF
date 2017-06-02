using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BankClassLib
{
    public enum AccountType
    {
        [Display(Name="Salary Account")]
        SalaryAccount,
        [Display(Name="Savings Account")]
        SavingsAccount,
        [Display(Name="Overdraft")]
        Overdraft
    };
    
    [DataContract]
    [KnownType(typeof(SalaryAccount))]
    [KnownType(typeof(SavingsAccount))]
    [KnownType(typeof(Overdraft))]
    public abstract class Account
    {
        protected string name;
        protected double balance;
        protected int accountNumber;
        protected AccountType accountType;
        protected List<Transaction> transactions;

        [DataMember]
        public List<Transaction> Transactions
        { 
            get
            {
                return this.transactions;
            }
        }
        [Display(Name="Account number")]
        [DataMember]
        public int AccountNumber
        {
            get { return this.accountNumber; }
        }
        [DataMember]
        public string Name
        {
            get { return this.name; }
        }
        [DataType(DataType.Currency)]
        [DataMember]
        public virtual double Balance
        {
            get { return this.balance; }
            set
            {
                double balanceTmp = value;
                if (balanceTmp < 0)
                {
                    throw new NegativeBalanceException(string.Format("Warning!\nThe account type for account number {0} does now allow a negative balance.\nThe current balance is {1:c}", this.accountNumber, this.balance));
                }
                else
                {
                    this.transactions.Add(new Transaction(this.AccountNumber, (value - this.balance)));
                    this.balance = value;
                }
            }
        }
        [Display(Name="Account type")]
        [DataMember]
        public AccountType AccountType
        {
            get { return accountType; }
        }
        public abstract void AddInterest();
    }
}
