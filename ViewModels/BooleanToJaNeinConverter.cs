using System.Globalization;

namespace Accounter.ViewModels

{
    public class BooleanToJaNeinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int boolValue)
            {
                return boolValue == 1 ? "Ja" : "Nein";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

