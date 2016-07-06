namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class OldValueConverter : IMultiValueConverter
    {
        public static readonly OldValueConverter Default = new OldValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var formatter = values[0] as INumericFormatter;
            if (formatter == null)
            {
                return "first parameter must be a INumericFormatter";
            }

            return $"Old value: {formatter.Format(values[1] as IFormattable)}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
