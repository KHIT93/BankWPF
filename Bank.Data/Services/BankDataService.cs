﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Data.Repositories;
using Bank.Data.Exceptions;

namespace Bank.Data.Services
{
    public class BankDataService : IBankService
    {
        private static BankDataService _instance;
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
            return this._accounts.Create(account).ToString();
        }

        public string DeleteAccount(int accountNumber)
        {
            return this._accounts.Delete(this.GetAccount(accountNumber, false)).ToString();
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

        public string Transaction(double amount, int accountNumber)
        {
            return this._transactions.Create(new Transaction(this.GetAccount(accountNumber, false), amount)).ToString();
        }
    }
}
