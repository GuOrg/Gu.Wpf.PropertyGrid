namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Gu.Wpf.NumericInput;

    /// <inheritdoc />
    public class OldValueConverter : IMultiValueConverter
    {
        public static readonly OldValueConverter Default = new OldValueConverter();

        /// <inheritdoc />
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var formatter = values[0] as INumericFormatter;
            if (formatter == null)
            {
                return "first argument must be a IQuantityFormatter";
            }

            var row = values[0] as Row;
            if (row == null)
            {
                return "first argument must be a Row";
            }

            var oldValueStringFormat = row.OldValueStringFormat;
            if (!string.IsNullOrEmpty(oldValueStringFormat) &&
                FormatString.IsValidFormat(oldValueStringFormat, out var numberOfArguments, out var anyItemHasFormat))
            {
                if (numberOfArguments == 1 && anyItemHasFormat == false)
                {
                    var formattedValue = formatter.Format(row.OldValue as IFormattable);
                    return string.Format(row.OldValueStringFormat, formattedValue);
                }

                return string.Format(NumericBox.GetCulture(row), oldValueStringFormat, row.OldValue);
            }

            return oldValueStringFormat;
        }

        /// <inheritdoc />
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
