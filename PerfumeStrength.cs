using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_C_sharp2
{
    internal static class PerfumeStrength
    {

        public static int CalculateStrength(int outputVolume, int oilVolume)
        {
            int strength = 0;
            if (outputVolume == 5)
            {
                strength = 100 * oilVolume / 100;
            } 
            else if (outputVolume == 10)
            {
                strength = 100 * oilVolume / 200;
            }
            else if (outputVolume == 20)
            {
                strength = 100 * oilVolume / 400;
            }
            else if (outputVolume == 30)
            {
                strength = 100 * oilVolume / 600;
            }
            return strength;
        }
    }
}
