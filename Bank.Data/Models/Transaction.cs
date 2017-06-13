using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }
        public Transaction(Account account, double amount)
        {
            this.Account = account;
            this.Amount = amount;
            this.Timestamp = DateTime.Now;
        }

        public Transaction(Account account, double amount, string description)
        {
            this.Account = account;
            this.Amount = amount;
            this.Description = description;
            this.Timestamp = DateTime.Now;
        }

        [Display(Name = "Transaction ID")]
        public int Id { get; set; }

        [Display(Name = "Account number")]
        public virtual Account Account { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Display(Name = "Transaction Time")]
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        public String Description { get; set; }
    }
}
