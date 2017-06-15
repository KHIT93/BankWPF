using BankWPF.Helpers;
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
    /// Interaction logic for CreateTransactionWindow.xaml
    /// </summary>
    public partial class CreateTransactionWindow : Window
    {
        protected CreateTransactionViewModel vm;
        public CreateTransactionWindow(CreateTransactionViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = vm;
        }

        private void AmountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Utility.IsTextAllowed(e.Text);
        }
    }
}
