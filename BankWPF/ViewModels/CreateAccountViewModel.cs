using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public CreateAccountViewModel()
        {
            this.CreateNewAccountButtonCommand = new DelegateCommand(Save, CanSaveNewAccount);
        }
        public String Name { get; set; }
        public Double Balance { get; set; }
        public Customer Customer { get; set; }
        public String AccountType { get; set; }

        public ICommand CreateNewAccountButtonCommand { get; private set; }

        public void Save()
        {
            BankDataService.Instance.CreateAccount(Customer, Name, AccountType, Balance);
            
        }

        public void Save(object parameter)
        {
            this.Save();
            ((Window)parameter).DialogResult = true;
        }

        public ICollection<Customer> Customers
        {
            get
            {
                return BankDataService.Instance.GetCustomers();
            }
        }

        private bool CanSaveNewAccount(object parameter)
        {
            //Validate if all fields are filled
            return (this.AccountType != null && this.Customer != null && !String.IsNullOrEmpty(this.Name));
        }
    }
}
