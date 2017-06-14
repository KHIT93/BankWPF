using Bank.Data.Models;
using Bank.Security;
using BankWPF.Commands;
using Bank.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LogInButtonCommand { get; protected set; }
        public ICommand ExitApplicationCommand { get; protected set; }

        public string Username { get; set; }
        public string Password { get; set; }

        private string _loginButtonText;
        public string LoginButtonText
        {
            get
            {
                return this._loginButtonText;
            }
            set
            {
                this._loginButtonText = value;
                RaisePropertyChanged("LoginButtonText");
            }
        }

        private bool CanLogin = true;

        public LoginViewModel()
        {
            this.LogInButtonCommand = new DelegateCommand(LogIn, CanLogIn);
            this.ExitApplicationCommand = new DelegateCommand(ExitApplication, CanExitApplication);
            this.LoginButtonText = "Log in";
        }

        public async void LogIn(object parameter)
        {
            this.CanLogin = false;
            this.LoginButtonText = "Signing in...";
            if(!String.IsNullOrEmpty(this.Username) && !String.IsNullOrEmpty(this.Password))
            {
                if (await Task<bool>.Run(() => Identity.Authenticate(new User { Username = this.Username, Password = this.Password }, this.Password)))
                {
                    await Task.Run(() => BankDataService.Instance.SetSignedInUser(this.Username));
                    (new MainWindow()).Show();
                    ((Window)parameter).Close();
                }
                else
                {
                    MessageBox.Show("Login error");
                }
                this.CanLogin = true;
                this.LoginButtonText = "Log in";
            }
            else
            {
                MessageBox.Show("You need to fill  in username and password");
            }
        }

        public bool CanLogIn(object parameter)
        {
            //return (!String.IsNullOrEmpty(this.Username) && !String.IsNullOrEmpty(this.Password));
            return this.CanLogin;
        }

        public void ExitApplication(object parameter)
        {
            App.Current.Shutdown();
        }

        public bool CanExitApplication(object parameter)
        {
            return true;
        }
    }
}
