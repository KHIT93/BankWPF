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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankWPF.UserControls
{
    /// <summary>
    /// Interaction logic for QuickTransactionWidget.xaml
    /// </summary>
    public partial class QuickTransactionWidget : UserControl
    {
        protected QuickTransactionViewModel vm;
        public QuickTransactionWidget()
        {
            InitializeComponent();
            this.vm = new QuickTransactionViewModel();
            this.DataContext = vm;
        }

        private void CheckForAlphaNumericValues(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Utility.IsTextAllowed(e.Text);
        }
    }
}
