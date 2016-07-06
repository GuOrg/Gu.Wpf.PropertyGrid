namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Gu.Wpf.NumericInput;

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

            var row = values[0] as Row;
            if (row == null)
            {
                return "first parameter must be a Row";
            }

            var oldValueStringFormat = row.OldValueStringFormat;
            bool? anyItemHasFormat;
            int numberOfArguments;
            if (FormatString.IsValidFormat(oldValueStringFormat, out numberOfArguments, out anyItemHasFormat))
            {
                if (numberOfArguments == 1 && anyItemHasFormat == false)
                {
                    var formattedValue = formatter.Format(values[1] as IFormattable);
                    return string.Format(row.OldValueStringFormat, formattedValue);
                }

                return string.Format(NumericBox.GetCulture(row), oldValueStringFormat, row.OldValue);
            }

            return oldValueStringFormat;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
