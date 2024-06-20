using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_C_sharp2
{
    public class Oil
    {
        public string OilName { get; set; }
        public string CompositionPart { get; set; }
        public string ScentType { get; set; }

        public Oil(string oilName, string compositionPart, string scentType)
        {
            OilName = oilName;
            CompositionPart = compositionPart;
            ScentType = scentType;
        }
    }


}
