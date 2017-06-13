using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class ShowCustomerViewModel : BaseViewModel
    {
        private Customer model;
        public ShowCustomerViewModel(Customer model)
        {
            this.model = model;
        }
        public string WindowTitle
        {
            get
            {
                return $"Details for customer {this.model.FullNameWithCompany}";
            }
        }

        public string FirstName
        {
            get
            {
                return this.model.FirstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.model.LastName;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.model.CompanyName;
            }
        }

        public string VATNo
        {
            get
            {
                return this.model.VATNo;
            }
        }

        public ICollection<Account> Accounts
        {
            get
            {
                return this.model.Accounts;
            }
        }

        public string FullName
        {
            get
            {
                return this.model.FullName;
            }
        }
    }
}
