using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string VATNo { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        public string FullNameWithCompany
        {
            get
            {
                return (String.IsNullOrEmpty(this.CompanyName)) ? this.FullName : $"{this.CompanyName} ({this.FirstName} {this.LastName})";
            }
        }

    }
}
