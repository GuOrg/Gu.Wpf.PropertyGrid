namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(FirstValidationResultConverter))]
    public class FirstValidationResultConverter : MarkupExtension, IValueConverter
    {
        public static readonly FirstValidationResultConverter Default = new FirstValidationResultConverter();

        // ReSharper disable once EmptyConstructor think the xaml parse needs it
        public FirstValidationResultConverter()
        {
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (value is IEnumerable<object> enumerable)
            {
                value = enumerable.FirstOrDefault();
            }

            if (value is ValidationError error)
            {
                return error.ErrorContent;
            }

            return value;
        }

        /// <inheritdoc />
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(FirstValidationResultConverter)} only supports one-way conversion.");
        }
    }
}
