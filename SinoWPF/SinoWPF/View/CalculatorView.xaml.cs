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

namespace SinoWPF.View
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        ViewModel.CalculatorViewModel vm = new ViewModel.CalculatorViewModel();
        public CalculatorView()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Digital_Click(object sender, RoutedEventArgs e)
        {
            if (vm.Display != "")
            {
                vm.A = "";
                vm.Display = "";
                vm.operatorSing = "";
                vm.B = "";
            }

            if (vm.operatorSing=="")
                vm.A += ((Button)sender).Content.ToString();
            else
                vm.B += ((Button)sender).Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            vm.operatorSing= ((Button)sender).Content.ToString();
        }
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            vm.Display = " = "+vm.result.ToString();
        }
    }
}
