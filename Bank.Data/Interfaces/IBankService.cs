using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface IBankService
    {
        String CreateAccount(Customer customer, string name, string accountType, double balance = 0);
        String DeleteAccount(int accountNumber);
        String Transaction(double amount, int accountNumber);
        Account GetAccount(int AccountId, bool GetAllRelationships);
        ICollection<Account> GetAccounts();
        String AddInterest();
        Customer GetCustomer(int Id, bool GetAllRelationships);
        ICollection<Customer> GetCustomers();
    }
}
