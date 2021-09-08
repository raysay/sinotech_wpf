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
    /// Interaction logic for step1.xaml
    /// </summary>
    public partial class step1 : Window
    {
        ViewModel.MRTStationVM vm = new ViewModel.MRTStationVM();
        public step1()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void CheckComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ViewModel.MRTLevelVM item in (sender as HandyControl.Controls.CheckComboBox).Items)
            {
                item.selected = false;
            }

            foreach (ViewModel.MRTLevelVM item in (sender as HandyControl.Controls.CheckComboBox).SelectedItems)
            {
                item.selected = true;
            }
            input_refresh();
            DrawLevels();
        }

        void input_refresh()
        {
            level_input.Children.Clear();
            foreach (var level in vm.Levels)
            {
                if (level.selected)
                {
                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;
                    panel.Children.Add(new Label { Content = level.name, BorderBrush = Brushes.Transparent });
                    TextBox tb = new TextBox { Text = level.height.ToString(), Width = 100, TextAlignment = TextAlignment.Right, Tag = level.index };
                    tb.TextChanged += Tb_TextChanged;
                    panel.Children.Add(tb);
                    panel.Children.Add(new Label { Content = "m", BorderBrush = Brushes.Transparent });
                    level_input.Children.Add(panel);
                }
            }
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.Levels[(int)(sender as TextBox).Tag].height =Model.BasicStationInfo.ToDouble((sender as TextBox).Text);

            DrawLevels();
        }

        public void DrawLevels()
        {
            canvas.Children.Clear();

            List<double> heights = new List<double>();
            foreach (var floor in vm.Levels)
            {
                if (floor.selected)
                    heights.Add(floor.height);
            }
            
            foreach (var floor in vm.Levels)
            {
                if (floor.selected)
                {
                    double c_height = change_coordinate(floor.height, heights.Max(), heights.Min(),canvas.ActualHeight);
                    Line newLine = new Line
                    {
                        X1 = 50,
                        Y1 = c_height,
                        X2 = canvas.ActualWidth - 50,
                        Y2 = c_height,
                        Stroke = Brushes.Blue,
                        StrokeThickness = 1
                    };
                    canvas.Children.Add(newLine);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = floor.name.ToString();
                    textBlock.Foreground = new SolidColorBrush(Colors.Blue);
                    Canvas.SetLeft(textBlock, 10);
                    Canvas.SetTop(textBlock, c_height - 10);
                    canvas.Children.Add(textBlock);

                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = floor.height.ToString() + " m";
                    textBlock1.Foreground = new SolidColorBrush(Colors.Blue);
                    Canvas.SetLeft(textBlock1, canvas.ActualWidth - 40);
                    Canvas.SetTop(textBlock1, c_height - 10);
                    canvas.Children.Add(textBlock1);
                }
            }
        }

        double change_coordinate(double height, double max, double min, double canvas_height)
        { 
            return canvas_height - (canvas_height / (max - min + 2) * (height - min)) - 20;
        }

    }
}
