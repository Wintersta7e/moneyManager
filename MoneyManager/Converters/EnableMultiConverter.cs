using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace MoneyManager.Converters
{
    public class EnableMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count() < 2) return false;

            return ((string) values[0]).Length > 0 && ((string) values[1]).Length > 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}