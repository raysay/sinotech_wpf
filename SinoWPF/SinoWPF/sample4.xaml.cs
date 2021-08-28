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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class sample4 : Window
    {
        public sample4()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(10000);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pbar.Value++;
            if (pbar.Value > 100)
                timer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pbar.Value = 0;
            timer.Start();
        }
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
    }
}
