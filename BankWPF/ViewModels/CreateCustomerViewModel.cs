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
    public class CreateCustomerViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string VATNo { get; set; }
        public ICommand CreateNewCustomerButtonCommand { get; set; }

        public CreateCustomerViewModel()
        {
            this.CreateNewCustomerButtonCommand = new DelegateCommand(Save, CanSave);
        }

        public void Save()
        {
            BankDataService.Instance.CreateCustomer(this.FirstName, this.LastName, this.CompanyName, this.VATNo);
        }

        public void Save(object parameter)
        {
            this.Save();
            ((Window)parameter).DialogResult = true;
        }

        public bool CanSave(object parameter)
        {
            return (!String.IsNullOrEmpty(this.FirstName) && !String.IsNullOrEmpty(this.LastName));
        }
    }
}
