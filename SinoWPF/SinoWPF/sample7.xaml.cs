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

namespace SinoWPF
{
    /// <summary>
    /// Interaction logic for sample7.xaml
    /// </summary>
    public partial class sample7 : Window
    {
        public sample7()
        {
            InitializeComponent();

            Binding binding = new Binding("Value");
            binding.Source = slider1;
            pbar1.SetBinding(ProgressBar.ValueProperty, binding);
        }
    }
}
