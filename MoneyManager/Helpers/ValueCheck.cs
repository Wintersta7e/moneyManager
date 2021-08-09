using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MoneyManager.Helpers
{
    class ValueCheck
    {
        private static Regex doubleReg = new Regex("^[.][0-9-]+$|^[0-9-]*[.]{0,1}[0-9-]*$");

        public static bool isDouble(string number)
        {
            return !doubleReg.IsMatch(number);
        }

        public static Decimal getVal(string valueToParse)
        {
            decimal val;
            if (!Decimal.TryParse(valueToParse, NumberStyles.Currency, new CultureInfo("de-DE"), out val))
                return 0;
            return val;
        }
    }
}