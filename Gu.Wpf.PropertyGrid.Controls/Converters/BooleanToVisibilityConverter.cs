namespace Gu.Wpf.PropertyGrid
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
                return this.WhenNull;
            }

            if (Equals(value, BooleanBoxes.True))
            {
                return this.WhenTrue;
            }

            if (Equals(value, BooleanBoxes.False))
            {
                return this.WhenFalse;
            }

            throw new ArgumentOutOfRangeException("Expected value to be of type Nullable<bool>");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(BooleanToVisibilityConverter)} is only for OneWay");
        }
    }
}
