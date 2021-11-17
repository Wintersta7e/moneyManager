using System.Globalization;
using System.Text.RegularExpressions;

namespace MoneyManager.Helpers
{
    internal static class ValueCheck
    {
        private static readonly Regex doubleReg = new Regex("^[.][0-9-]+$|^[0-9-]*[.]{0,1}[0-9-]*$");

        public static bool IsDouble(string number)
        {
            return !doubleReg.IsMatch(number);
        }

        public static decimal GetVal(string valueToParse)
        {
            return !decimal.TryParse(valueToParse, NumberStyles.Currency, new CultureInfo("de-DE"), out decimal val) ? 0 : val;
        }
    }
}