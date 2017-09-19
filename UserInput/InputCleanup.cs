using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public static class InputCleanup
    {
        public static string WriteAsFraction(float input)
        {
            string output = "";
            if (input < 0)
            {
                output += "-";
                input *= -1;
            }
            if (input > 1)
            {
                int floor = Convert.ToInt32(Math.Floor(input));
                output += $"{Convert.ToString(floor)} ";
                input -= floor;
            }
            for (int denominator = 2; denominator < 200; denominator++)
            {
                float numerator = input * denominator;
                float difference = Math.Abs(numerator - (float)Math.Round(numerator));
                if (difference < 0.001*input)
                {
                    output += $"{numerator}/{denominator}";
                    return output;
                }
            }
            return null;
        }
    }
}
