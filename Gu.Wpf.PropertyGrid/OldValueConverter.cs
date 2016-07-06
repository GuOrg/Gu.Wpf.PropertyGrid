namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class OldValueConverter : IMultiValueConverter
    {
        public static readonly OldValueConverter Default = new OldValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var row = values[0] as Row;
            if (row == null)
            {
                return "first parameter must be a Row";
            }

            return string.Format(culture, row.OldValueStringFormat, row.OldValue);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
