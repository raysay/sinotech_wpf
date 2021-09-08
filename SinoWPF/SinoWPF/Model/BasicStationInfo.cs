using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoWPF.Model
{
    public static class BasicStationInfo
    {
        public static string[] level_names = new string[] { "出入口", "地面層", "轉折層", "穿堂層", "設備層", "月台層", "軌道層" };
        public static double ToDouble(string s)
        {
            if (s == "")
                return 0;
            else
                return Convert.ToDouble(s);
        }
    }
}
