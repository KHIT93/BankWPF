using Bank.Data.Context;
using Bank.Data.Models;
using Bank.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    public class CustomersMainViewModel : BaseViewModel
    {
        protected ObservableCollection<Customer> _customers;
        protected Customer _selected;
        public void CollectData()
        {
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            using (var context = new BankDatabaseContext())
            {
                foreach (Customer customer in context.Customers.ToList())
                {
                    collection.Add(customer);
                }
            }
            this.Customers = collection;
        }

        public async Task CollectDataAsync()
        {
            await Task.Run(() =>
            {
                ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
                using (var context = new BankDatabaseContext())
                {
                    foreach (Customer customer in context.Customers.ToList())
                    {
                        collection.Add(customer);
                    }
                }
                this.Customers = collection;
            });
        }
        
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this._customers;
            }
            protected set
            {
                this._customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public Customer SelectedCustomer
        {
            get
            {
                return this._selected;
            }
            set
            {
                this._selected = value;
                RaisePropertyChanged("SelectedCustomer");
                RaisePropertyChanged("CustomerIsSelected");
            }
        }

        public bool CustomerIsSelected
        {
            get
            {
                return this._selected != null;
            }
        }
    }
}
