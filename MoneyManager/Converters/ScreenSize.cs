
using System;
using System.Globalization;
using System.Windows.Data;

namespace MoneyManager.Converters
{
    public class ScreenSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double screenSize = System.Convert.ToDouble(value);
            double percent = System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);

            return ((int)(screenSize * percent)).ToString("G0", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
