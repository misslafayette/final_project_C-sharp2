﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_C_sharp2
{
    internal class PerfumeStrength
    {
        public static int CalculateStrength(int num1, int num2, int num3)
        {
            int strength = 0;
            strength = 100 * ( num1 + num2 + num3) / 200;
            return strength;
        }

        public static int CalculateFor5mL(int num1, int num2, int num3) 
        {
            int strength = 0;
            strength = 100 * (num1 + num2 + num3) / 100;
            return strength;
        }

        public static int CalculateFor20mL(int num1, int num2, int num3)
        {
            int strength = 0;
            strength = 100 * (num1 + num2 + num3) / 400;
            return strength;
        }

        public static int CalculateFor30mL(int num1, int num2, int num3)
        {
            int strength = 0;
            strength = 100 * (num1 + num2 + num3) / 600;
            return strength;
        }
    }
}
