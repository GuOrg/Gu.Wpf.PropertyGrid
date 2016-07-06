namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public class OldValueConverter : IMultiValueConverter
    {
        public static readonly OldValueConverter Default = new OldValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var formatter = values[0] as IQuantityFormatter;
            if (formatter == null)
            {
                return "first parameter must be a IQuantityFormatter";
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
                    var formattedValue = formatter.Format(values[1] as IQuantity);
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
