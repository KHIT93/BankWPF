using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_DispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled " + e.Exception.GetType().ToString() +
                " exception was caught and ignored.");
            try
            {
                File.AppendAllText("log.txt", $"{DateTime.Now} - An error occurred during execution of the application. Please find the details below:\n {e.Exception.GetType().ToString()}\n{e.Exception.Message}\n{e.Exception.StackTrace}");
            }
            catch (Exception)
            {
                
            }
            MessageBox.Show(e.Exception.Message, "An application error occurred");
            e.Handled = true;
        }
    }
}
