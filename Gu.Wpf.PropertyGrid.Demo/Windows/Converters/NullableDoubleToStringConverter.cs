namespace Gu.Wpf.PropertyGrid.Demo.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class NullableDoubleToStringConverter : IValueConverter
    {
        public static readonly NullableDoubleToStringConverter Default = new NullableDoubleToStringConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "null";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string)value;
            if (string.IsNullOrEmpty(text) || text == "null")
            {
                return null;
            }

            return double.Parse(text, culture);
        }
    }
}