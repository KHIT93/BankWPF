using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BankClassLib
{
    public class Bank : IBank
    {
        string bankName;
        double inventory;
        List<Account> accounts;
        int[] accountTypes = new int[] { (int)AccountType.SalaryAccount, (int)AccountType.SavingsAccount, (int)AccountType.Overdraft };
        int accountCounter;

        public Bank(string bankName, double inventory)
        {
            this.bankName = bankName;
            this.inventory = inventory;
            accounts = new List<Account>();
            accountCounter = 0;
        }
        
        public string BankName
        {
            get { return this.bankName; }
            set { this.bankName = value; }
        }
        public double Inventory
        {
            get { return this.inventory; }
        }
        public List<Account> Accounts
        {
            get { return this.accounts; }
        }
        public string CMDStatus()
        {
            StringBuilder output = new StringBuilder();
            double total = this.inventory;
            foreach (Account account in accounts)
            {
                output.Append(string.Format("Account number {0} balance: {1," + (31 - (account.AccountNumber.ToString().Length)) + ":c}\n", account.AccountNumber, account.Balance));
                total += account.Balance;
            }
            output.Append(string.Format("Bank inventory: {0,40:c}\n", total));
            return Convert.ToString(output);
        }
        public string Status()
        {
            StringBuilder output = new StringBuilder();
            double total = this.inventory;
            foreach (Account account in accounts)
            {
                if (account.Balance < 0)
                {
                    total -= -account.Balance;
                }
                else
                {
                    total += account.Balance;
                }
            }
            return string.Format("{0:c}", total);
        }
        public string CreateAccount(string name, AccountType accountType, double balance = 0)
        {
            if (this.accountTypes.Contains((int)accountType))
            {
                if (name.Length == 0)
                {
                    throw new InvalidAccountNameException();
                }
                else
                {
                    this.accountCounter++;
                    switch (accountType)
                    {
                        case AccountType.SalaryAccount:
                            this.accounts.Add(new SalaryAccount(name, this.accountCounter, balance));
                            break;
                        case AccountType.SavingsAccount:
                            this.accounts.Add(new SavingsAccount(name, this.accountCounter, balance));
                            break;
                        case AccountType.Overdraft:
                            this.accounts.Add(new Overdraft(name, this.accountCounter, balance));
                            break;
                        default:
                            break;
                    }
                    return string.Format("New {0} created for {1} with account number {2}", accountType, name, accountCounter);
                }
            }
            else
            {
                return string.Format("The account type {0} does not exists in our bank", accountType);
            }
        }
        public string DeleteAccount(int accountNumber)
        {
            return (this.accounts.Remove(GetAccount(accountNumber))) ? string.Format("The account with account number {0} has been removed", accountNumber) : string.Format("The account with account number {0} could not be removed", accountNumber);
        }
        public string Transaction(double amount, int accountNumber)
        {
            if (this.accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                int index = this.accounts.FindIndex(a => a.AccountNumber == accountNumber);
                this.accounts[index].Balance += amount;
                return string.Format("Deposited {0:c} into account number {1}", amount, accountNumber);
            }
            else
            {
                throw new InvalidAccountException(string.Format("The account number {0} does not exist", accountNumber));
            }

        }
        public string Deposit(double amount, int accountNumber)
        {
            if (this.accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                int index = this.accounts.FindIndex(a => a.AccountNumber == accountNumber);
                this.accounts[index].Balance += amount;
                return string.Format("Deposited {0:c} into account number {1}", amount, accountNumber);
            }
            else
            {
                throw new InvalidAccountException(string.Format("The account number {0} does not exist", accountNumber));
            }

        }
        public string Withdraw(double amount, int accountNumber)
        {
            if (this.accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                int index = this.accounts.FindIndex(a => a.AccountNumber == accountNumber);
                StringBuilder output = new StringBuilder();
                this.accounts[index].Balance -= amount;
                output.Append(string.Format("{0:c} has been withdrawn from account number {1}", amount, accountNumber));
                return output.ToString();
            }
            else
            {
                throw new InvalidAccountException(string.Format("The account number {0} does not exist", accountNumber));
            }
        }

        public string BalanceFromString(string accountNumber)
        {
            return this.Balance(Convert.ToInt32(accountNumber));
        }

        public string Balance(int accountNumber)
        {
            if (this.accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                int index = this.accounts.FindIndex(a => a.AccountNumber == accountNumber);
                StringBuilder output = new StringBuilder();
                output.Append(string.Format("Account number {0} balance: {1," + (31 - (this.accounts[index].AccountNumber.ToString().Length)) + ":c}\n", accountNumber, this.accounts[index].Balance));
                return output.ToString();
            }
            else
            {
                throw new InvalidAccountException(string.Format("The account number {0} does not exist", accountNumber));
            }
        }

        public Account GetAccountFromString(string accountNumber)
        {
            return this.GetAccount(Convert.ToInt32(accountNumber));
        }

        public Account GetAccount(int accountNumber)
        {
            if (this.accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                return this.accounts.Find(a => a.AccountNumber == accountNumber);
            }
            else
            {
                throw new InvalidAccountException(string.Format("The account with account number {0} does not exist", accountNumber));
            }
        }
        public List<Account> GetAccounts()
        {
            return this.Accounts;
        }
        public string AddInterest()
        {
            foreach (Account item in this.accounts)
            {
                item.AddInterest();
            }
            return string.Format("Interests for all accounts have been added");
        }
    }
}
