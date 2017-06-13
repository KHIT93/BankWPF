using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankWPF.Views
{
    /// <summary>
    /// Interaction logic for CreateRawTransactionWindow.xaml
    /// </summary>
    public partial class CreateRawTransactionWindow : Window
    {
        protected CreateTransactionViewModel vm;
        public CreateRawTransactionWindow()
        {
            InitializeComponent();
            this.vm = new CreateTransactionViewModel();
            this.DataContext = vm;
        }

        private void CreateNewTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            this.vm.Save();
            DialogResult = true;
        }
    }
}
