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
    /// Interaction logic for CalculateInterestsWindow.xaml
    /// </summary>
    public partial class CalculateInterestsWindow : Window
    {
        protected CalculateInterestsViewModel vm;
        public CalculateInterestsWindow()
        {
            InitializeComponent();
            this.vm = new CalculateInterestsViewModel();
            this.DataContext = vm;
            Task.Run(() => this.vm.CollectDataAsync());
        }

        private void CalculateForAllRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.vm.SelectedOption = "All";
        }

        private void CalculateForSingleAccountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.vm.SelectedOption = "Single";
        }
    }
}
