using System;
using System.Text.RegularExpressions;

namespace MoneyManager.Helpers
{
    internal class ValueCheck
    {
        private static Regex doubleReg = new Regex("^[.][0-9-]+$|^[0-9-]*[.]{0,1}[0-9-]*$");

        public static bool isDouble(string number)
        {
            return !doubleReg.IsMatch(number);
        }

        public static double getVal(string valueToParse)
        {
            double val;
            if (!Double.TryParse(valueToParse, out val))
                return 0;
            return val;
        }
    }
}