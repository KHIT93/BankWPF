using Bank.Data.Models;
using Bank.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public String Name { get; set; }
        public Double Balance { get; set; }
        public Customer Customer { get; set; }
        public String AccountType { get; set; }

        public void Save()
        {
            BankDataService.Instance.CreateAccount(Customer, Name, AccountType, Balance);
        }

        public ICollection<Customer> Customers
        {
            get
            {
                return BankDataService.Instance.GetCustomers();
            }
        }
    }
}
