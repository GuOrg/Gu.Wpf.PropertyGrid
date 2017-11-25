namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public sealed class OldValueConverter : IMultiValueConverter
    {
        /// <summary> Gets the default instance </summary>
        public static readonly OldValueConverter Default = new OldValueConverter();

        /// <inheritdoc />
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var row = values[0] as Row;
            if (row == null)
            {
                return "first parameter must be a Row";
            }

            var oldValueStringFormat = row.OldValueStringFormat;
            if (!string.IsNullOrEmpty(oldValueStringFormat) &&
                FormatString.IsValidFormat(oldValueStringFormat, out var numberOfArguments, out _))
            {
                if (numberOfArguments == 1)
                {
                    return string.Format(culture, oldValueStringFormat, row.OldValue);
                }
            }

            return oldValueStringFormat;
        }

        /// <inheritdoc />
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{this.GetType().Name} can only be used in one way bindings.");
        }
    }
}
