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

            var oldValueStringFormat = row.OldValueStringFormat;
            bool? anyItemHasFormat;
            int numberOfArguments;
            if (!string.IsNullOrEmpty(oldValueStringFormat) &&
                FormatString.IsValidFormat(oldValueStringFormat, out numberOfArguments, out anyItemHasFormat))
            {
                if (numberOfArguments == 1)
                {
                    return string.Format(culture, oldValueStringFormat, row.OldValue);
                }
            }

            return oldValueStringFormat;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{this.GetType().Name} can only be used in one way bindings.");
        }
    }
}
