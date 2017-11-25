namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <inheritdoc />
    [ValueConversion(typeof(bool), typeof(bool))]
    public sealed class InvertBoolConverter : IValueConverter
    {
        /// <summary> Gets the default instance </summary>
        public static readonly InvertBoolConverter Default = new InvertBoolConverter();

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}