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
    /// Interaction logic for sample10.xaml
    /// </summary>
    public partial class sample10 : Window
    {
        public sample10()
        {
            InitializeComponent();
        }
        bool if_mosuse_down=false;
        Point last_point;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if_mosuse_down = true;
            last_point = e.GetPosition(this);
            //MessageBox.Show(e.GetPosition(this).X.ToString() + "," + e.GetPosition(this).Y.ToString());
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (if_mosuse_down) { 
                Point thisPoint = e.GetPosition(this);
                canvas.Children.Add(new Line() { X1 = last_point.X, Y1 = last_point.Y, X2 = thisPoint.X, Y2 = thisPoint.Y, Stroke = thisColor });
                last_point = thisPoint;
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if_mosuse_down = false;
        }
        Brush thisColor=Brushes.Black;
        private void colorPicker1_Confirmed(object sender, HandyControl.Data.FunctionEventArgs<Color> e)
        {
            thisColor = colorPicker1.SelectedBrush;
        }
    }
}
