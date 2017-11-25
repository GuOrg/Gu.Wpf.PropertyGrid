namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// A value converter as a markup extension. Use it like this in xaml: Converter={propertyGrid:BooleanToVisibilityConverter WhenTrue=Visible, WhenFalse=Hidden}
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    [MarkupExtensionReturnType(typeof(BooleanToVisibilityConverter))]
    public class BooleanToVisibilityConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets the <see cref="Visibility"/> when the converter value is true. Default is <see cref="Visibility.Visible"/>
        /// </summary>
        public Visibility WhenTrue { get; set; } = Visibility.Visible;

        /// <summary>
        /// Gets or sets the <see cref="Visibility"/> when the converter value is false. Default is <see cref="Visibility.Collapsed"/>
        /// </summary>
        public Visibility WhenFalse { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the <see cref="Visibility"/> when the converter value is null. Default is <see cref="Visibility.Collapsed"/>
        /// </summary>
        public Visibility WhenNull { get; set; } = Visibility.Collapsed;

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        /// <inheritdoc/>
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

            throw new ArgumentOutOfRangeException(nameof(value), value, "Expected value to be of type bool or Nullable<bool>");
        }

        /// <inheritdoc/>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(BooleanToVisibilityConverter)} is only for OneWay bindings");
        }
    }
}
