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
    /// Interaction logic for sample2.xaml
    /// </summary>
    public partial class sample2 : Window
    {
        public sample2()
        {
            InitializeComponent();
        }
        int count = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count++;
            label1.Content = $"click {count} times";
        }
    }
}
