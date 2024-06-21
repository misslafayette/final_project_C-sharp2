using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace final_project_C_sharp2
{
    public class Perfume
    {
        public string PerfumeName { get; set; }
        public int Oil1Amount { get; set; }
        public int Oil2Amount { get; set; }
        public int Oil3Amount { get; set; }
        public string Oil1 { get; set; }
        public string Oil2 { get; set; }
        public string Oil3 { get; set; }
        public bool IncludeFields { get; set; }

        public Perfume(string perfumeName, int oil1Amount, int oil2Amount, int oil3Amount, string oil1, string oil2, string oil3)
        {
            PerfumeName = perfumeName;
            Oil1Amount = oil1Amount;
            Oil2Amount = oil2Amount;
            Oil3Amount = oil3Amount;
            Oil1 = oil1;
            Oil2 = oil2;
            Oil3 = oil3;
        }

    }
}
