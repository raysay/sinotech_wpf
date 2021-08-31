using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoWPF.Model
{
    public class CalculatorModel
    {
        public CalculatorModel()
        {
            A = "";
            B = "";
            operatorSing = "";
            Display = "";

        }
        public string A { get; set; }
        public string B;
        public string operatorSing;
        public string Display;
        public double result;
    }
}
