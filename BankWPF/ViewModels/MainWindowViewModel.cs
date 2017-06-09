using System.Windows.Controls;

namespace BankWPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        protected string _bankName;
        protected UserControl _currentControl;
        public string BankName
        {
            get
            {
                return this._bankName;
            }
            protected set
            {
                this._bankName = value;
                RaisePropertyChanged("BankName");
            }
        }

        public UserControl CurrentControl
        {
            get
            {
                return this._currentControl;
            }
            private set
            {
                this._currentControl = value;
                RaisePropertyChanged("CurrentControl");
            }
        }

        public MainWindowViewModel()
        {
            Bank.Data.Services.BankDataService.Instance.SetBankName("EUC Banken");
            this.BankName = Bank.Data.Services.BankDataService.Instance.BankName;
        }

        public void SetCurrentUserControl(UserControl control)
        {
            if(this._currentControl != null)
            {
                this.RemoveCurrentUserControl();
            }
            this._currentControl = control;
        }

        public void RemoveCurrentUserControl()
        {
            this._currentControl = null;
        }
    }
}
