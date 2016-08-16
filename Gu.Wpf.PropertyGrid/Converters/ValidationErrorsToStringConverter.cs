namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class ValidationErrorsToStringConverter : MarkupExtension, IValueConverter
    {
        public static readonly ValidationErrorsToStringConverter Default = new ValidationErrorsToStringConverter();

        public ValidationErrorsToStringConverter()
        {
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var enumerable = value as IEnumerable<object>;
            if (enumerable != null)
            {
                return ValidationErrorToStringConverter.Default.Convert(enumerable.FirstOrDefault(), targetType, parameter, culture);
            }

            return ValidationErrorToStringConverter.Default.Convert(value, targetType, parameter, culture);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{this.GetType().Name} only supports one-way conversion.");
        }
    }
}