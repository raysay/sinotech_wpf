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
    /// Interaction logic for sample5.xaml
    /// </summary>
    public partial class sample5 : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public sample5()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(10000);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            pbar.Progress++;
            wpbar.Value++;
            if (pbar.Progress > 100)
                timer.Stop();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(datetimepicker1.SelectedDateTime.ToString());
            HandyControl.Controls.Dialog.Show(new dialog(datetimepicker1.SelectedDateTime.ToString()));
            
        }

        private void pbar_Checked(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
