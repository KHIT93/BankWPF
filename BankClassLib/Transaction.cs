using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace BankClassLib
{
    [DataContract]
    public class Transaction
    {
        public Transaction(int accountNumber, double amount)
        {
            this.Id = TransactionCounter++;
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            this.Timstamp = DateTime.Now;
        }
        [DataMember]
        public static int TransactionCounter = 1;

        [Display(Name = "Transaction ID")]
        [DataMember]
        public int Id { get; set; }

        [Display(Name = "Account number")]
        [DataMember]
        public int AccountNumber { get; set; }

        [DataType(DataType.Currency)]
        [DataMember]
        public double Amount { get; set; }

        [Display(Name = "Transaction Time")]
        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime Timstamp { get; set; }
    }
}
