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
        private List<Oil> _oils;

        public Perfume(string perfumeName, List<Oil> oils)
        {
            PerfumeName = perfumeName;
            _oils = oils.ToList();
        }

        public void ConstructPerfume() { }
    }
}
