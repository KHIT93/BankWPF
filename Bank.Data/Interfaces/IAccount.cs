using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface IAccount
    {
        Int32 AccountId { get; set; }
        String Name { get; set; }
        Double Balance { get; set; }
        Customer Customer { get; set; }
        ICollection<Transaction> Transactions { get; set; }
        void AddInterest();
    }
}
