using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoWPF.ViewModel
{
    public class CalculatorViewModel: ViewModelBase
    {
        private Model.CalculatorModel calcModel;
        public CalculatorViewModel()
        {
            calcModel = new Model.CalculatorModel();
        }

        public string A {
            get => calcModel.A;
            set {
                calcModel.A = value;
                OnPropertyChanged();
            }
        }
        public string B
        {
            get => calcModel.B;
            set
            {
                calcModel.B = value;
                OnPropertyChanged();
            }
        }
        public string operatorSing
        {
            get => calcModel.operatorSing;
            set
            {
                calcModel.operatorSing = value;
                OnPropertyChanged();
            }
        }
        public string Display
        {
            get => calcModel.Display;
            set
            {
                calcModel.Display = value;
                OnPropertyChanged();
            }
        }

        public double result {
            get {
                double _a = Convert.ToDouble( calcModel.A==""?"0": calcModel.A);
                double _b = Convert.ToDouble(calcModel.B == "" ? "0" : calcModel.B);
                if (calcModel.operatorSing == "+")
                    return _a + _b;
                else if (calcModel.operatorSing == "-")
                    return _a - _b;
                if (calcModel.operatorSing == "*")
                    return _a * _b;
                if (calcModel.operatorSing == "/")
                    return _a / _b;
                else
                    return 0;
            }
        }
    }
}
