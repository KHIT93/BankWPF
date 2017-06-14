using Bank.Data.Context;
using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using BankWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class CustomersMainViewModel : BaseViewModel
    {
        protected ObservableCollection<Customer> _customers;
        protected Customer _selected;

        public CustomersMainViewModel()
        {
            this.CreateNewCustomerButtonCommand = new DelegateCommand(CreateNewCustomerButtonClick, CanCreateCustomer);
            this.ShowCustomerButtonCommand = new DelegateCommand(ShowCustomerButtonClick, CustomerSelected);
        }
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

        private bool CustomerSelected(object parameter)
        {
            return this.CustomerIsSelected;
        }

        public ICommand ShowCustomerButtonCommand { get; set; }
        public ICommand CreateNewCustomerButtonCommand { get; set; }

        private void CreateNewCustomerButtonClick(object parameter)
        {
            if ((new CreateCustomerWindow()).ShowDialog() == true)
            {
                Task.Run(() => (this.CollectDataAsync()));
            }
        }
        private bool CanCreateCustomer(object parameter)
        {
            return true;
        }

        private void ShowCustomerButtonClick(object parameter)
        {
            (new ShowCustomerWindow
                (
                    new ShowCustomerViewModel
                    (
                        BankDataService.Instance.GetCustomer
                        (
                            this.SelectedCustomer.Id, true
                        )
                    )
                )
            ).Show();
    }
    }
}
