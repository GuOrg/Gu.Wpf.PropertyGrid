namespace Gu.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    public class BooleanToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public Visibility WhenTrue { get; set; } = Visibility.Visible;

        public Visibility WhenFalse { get; set; } = Visibility.Collapsed;

        public Visibility WhenNull { get; set; } = Visibility.Collapsed;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return WhenNull;
            }

            if (value == BooleanBoxes.True)
            {
                return WhenTrue;
            }

            if (value == BooleanBoxes.False)
            {
                return WhenFalse;
            }

            throw new ArgumentOutOfRangeException("Expected value to be of type Nullable<bool>");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(BooleanToVisibilityConverter)} is only for OneWay");
        }
    }
}
