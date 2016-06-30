namespace Gu.Wpf.PropertyGrid.Demo.Sandbox
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class StyleTargetTypeConverter : IValueConverter
    {
        public static readonly StyleTargetTypeConverter Default = new StyleTargetTypeConverter();

        public StyleTargetTypeConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Style)?.TargetType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{this.GetType().Name} only supports oneway bindings.");
        }
    }
}
