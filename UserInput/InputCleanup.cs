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
            return MathToolBox.Fractions.FractionToString(input);
        }
    }
}
