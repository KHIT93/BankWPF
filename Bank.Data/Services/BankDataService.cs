using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Data.Repositories;
using Bank.Data.Exceptions;
using Bank.Data.Context;

namespace Bank.Data.Services
{
    public class BankDataService : IBankService
    {
        private static BankDataService _instance;
        protected User user;
        protected string _bankName;
        protected IRepository<Account> _accounts = new AccountRepository();

        protected IRepository<Customer> _customers = new CustomerRepository();
        protected IRepository<Transaction> _transactions = new TransactionRepository();
        public BankDataService()
        {

        }
        public BankDataService(string bankName)
        {
            this._bankName = bankName;
            
        }

        public void SetBankName(string name)
        {
            this._bankName = name;
        }

        public static BankDataService Instance
        {
            get
            {
                return _instance ?? (_instance = new BankDataService());
            }
        }

        public string BankName
        {
            get
            {
                return this._bankName;
            }
        }

        public string AddInterest()
        {
            foreach (Account account in this._accounts.GetAll())
            {
                account.AddInterest();
            }
            return "Interest has been added for all accounts";
        }

        public string CreateAccount(Customer customer, string name, string accountType, double balance = 0)
        {
            Account account;
            switch (accountType)
            {
                case "Overdraft":
                    account = new Overdraft(name, balance);
                    break;
                case "SavingsAccount":
                    account = new SavingsAccount(name, balance);
                    break;
                case "SalaryAccount":
                    account = new SalaryAccount(name, balance);
                    break;
                default:
                    throw new InvalidAccountException("The chosen account type is not valid");
            }
            account.Customer = customer;
            return this._accounts.Create(account, this.user).ToString();
        }

        public string DeleteAccount(int accountNumber)
        {
            return this._accounts.Delete(accountNumber, this.user).ToString();
        }

        public Account GetAccount(int AccountId, bool GetAllRelationships)
        {
            return (GetAllRelationships == true) ? this._accounts.GetWithAll(AccountId) : this._accounts.Get(AccountId, null);
        }

        public Account GetAccountWithCustomer(int Id)
        {
            return this._accounts.Get(Id, "Customer");
        }

        public ICollection<Account> GetAccounts()
        {
            return this._accounts.GetAll();
        }

        public Customer GetCustomer(int Id, bool GetAllRelationships)
        {
            return (GetAllRelationships == true) ? this._customers.GetWithAll(Id) : this._customers.Get(Id, null);
        }

        public ICollection<Customer> GetCustomers()
        {
            return this._customers.GetAll();
        }

        public async Task<ICollection<Customer>> GetCustomersAsync()
        {
            return await Task.Run(() => this.GetCustomers());
        }

        public Customer CreateCustomer(string firstName, string lastName, string companyName, string vatNo)
        {
            return this._customers.Create(new Customer { FirstName = firstName, LastName = lastName, CompanyName = companyName, VATNo = vatNo }, this.user);
        }

        public string Transaction(double amount, int accountNumber, string description)
        {
            string output = this._transactions.Create(new Transaction(this.GetAccountWithCustomer(accountNumber), amount, description), this.user).ToString();
            Task.Run(() => this._accounts.CalculateBalanceForAccount(accountNumber));
            return output;
        }

        public void CalculateBalance()
        {
            foreach (Account account in this._accounts.GetAll())
            {
                this._accounts.CalculateBalanceForAccount(account.AccountId);
            }
        }

        public void SetSignedInUser(User user)
        {
            this.user = user;
        }

        public void SetSignedInUser(string username)
        {
            using (var context = new BankDatabaseContext())
            {
                this.SetSignedInUser(context.Users.Where(u => u.Username == username).First());
            }
        }

        public void SetSignedInUser(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                this.SetSignedInUser(context.Users.Find(Id));
            }
        }
    }
}
