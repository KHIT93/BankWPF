using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data.Interfaces;
using Bank.Data.Models;

namespace Bank.Data.Services
{
    class BankDataService : IBankService
    {
        protected string _bankName;
        public BankDataService(string bankName)
        {
            this._bankName = bankName;
        }

        public string AddInterest()
        {
            throw new NotImplementedException();
        }

        public string CreateAccount(string name, string accountType, double balance = 0)
        {
            throw new NotImplementedException();
        }

        public string DeleteAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public ICollection<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public string Transaction(double amount, int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
