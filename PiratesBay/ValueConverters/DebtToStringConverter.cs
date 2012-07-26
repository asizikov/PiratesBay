using System;
using System.Windows.Data;

namespace PiratesBay.ValueConverters
{
    public class DebtToStringConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var debt = System.Convert.ToDouble(value);

            return debt >= 0 ? "ПОЛУЧИТЬ:" : "ОТДАТЬ:";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
