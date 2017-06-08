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
        String CreateAccount(string name, string accountType, double balance = 0);
        string DeleteAccount(int accountNumber);
        string Transaction(double amount, int accountNumber);
        ICollection<Account> GetAccounts();
        string AddInterest();
    }
}
