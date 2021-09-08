using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SinoWPF.ViewModel
{
    public class MRTStationVM: ObservableObject
    {
        Model.MRTStation _station ;
        ObservableCollection<MRTLevelVM> _levels;
        public MRTStationVM()
        {
            _station = new Model.MRTStation();
            _levels = new ObservableCollection<MRTLevelVM>();
            for (int i = 0; i < Model.BasicStationInfo.level_names.Length; i++)
            {
                _levels.Add(new MRTLevelVM(Model.BasicStationInfo.level_names[i], i));
            }
        }

        public ObservableCollection<MRTLevelVM> Levels
        {
            get => _levels;
        }

        public double lenth { 
            get=> _station.lenth;
            set=> SetProperty(_station.lenth, value, _station, (u, n) => u.lenth = n); 
        }
        public double width
        {
            get => _station.width;
            set => SetProperty(_station.width, value, _station, (u, n) => u.width = n);
        }
        public double left
        {
            get => _station.left;
            set => SetProperty(_station.left, value, _station, (u, n) => u.left = n);
        }
        public double right
        {
            get => _station.right;
            set => SetProperty(_station.right, value, _station, (u, n) => u.lenth = n);
        }
        public double top
        {
            get => _station.top;
            set => SetProperty(_station.top, value, _station, (u, n) => u.top = n);
        }
        public double bottom
        {
            get => _station.bottom;
            set => SetProperty(_station.bottom, value, _station, (u, n) => u.bottom = n);
        }

        public void DrawLevels( CustomControl.PanAndZoomCanvas canvas)
        {
            canvas.Clear();

            List<double> heights = new List<double>();
            foreach (var floor in Levels)
            {
                if (floor.selected)
                    heights.Add(floor.height);
            }

            foreach (var floor in Levels)
            {
                if (floor.selected)
                {
                    double c_height = change_coordinate(floor.height, heights.Max(), heights.Min(), canvas.ActualHeight);
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
