using Bank.Data.Models;
using Bank.Data.Services;
using BankWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class QuickTransactionViewModel : BaseViewModel
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        protected bool transactionProcessing = false;

        public ICommand QuickTransactionSaveButtonCommand { get; protected set; }

        public QuickTransactionViewModel()
        {
            this.QuickTransactionSaveButtonCommand = new DelegateCommand(Save, CanSave);
        }

        public void Save(object parameter)
        {
            Task.Run(() =>
            {
                BankDataService.Instance.Transaction(-this.Amount, this.FromAccount, this.Description);
                BankDataService.Instance.Transaction(this.Amount, this.ToAccount, this.Description);
                this.FromAccount = 0;
                this.ToAccount = 0;
                this.Amount = 0;
                this.Description = String.Empty;
                RaisePropertyChanged("FromAccount");
                RaisePropertyChanged("ToAccount");
                RaisePropertyChanged("Amount");
                RaisePropertyChanged("Description");
            });
        }

        public bool CanSave(object parameter)
        {
            return ((this.FromAccount > 0 && this.Amount > 0 && this.ToAccount > 0 && String.IsNullOrEmpty(this.Description)) || this.transactionProcessing == false);
        }
    }
}
