using Bank.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class CreateCustomerViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string VATNo { get; set; }

        public void Save()
        {
            BankDataService.Instance.CreateCustomer(this.FirstName, this.LastName, this.CompanyName, this.VATNo);
        }
    }
}
