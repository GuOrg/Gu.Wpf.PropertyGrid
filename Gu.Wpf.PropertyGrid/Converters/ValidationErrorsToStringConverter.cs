namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(ValidationErrorsToStringConverter))]
    public sealed class ValidationErrorsToStringConverter : MarkupExtension, IValueConverter
    {
        /// <summary> Gets the default instance </summary>
        public static readonly ValidationErrorsToStringConverter Default = new ValidationErrorsToStringConverter();

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationErrorsToStringConverter"/> class.
        /// </summary>
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

            if (value is IEnumerable<object> enumerable)
            {
                return ValidationErrorToStringConverter.Default.Convert(enumerable.FirstOrDefault(), targetType, parameter, culture);
            }

            return ValidationErrorToStringConverter.Default.Convert(value, targetType, parameter, culture);
        }

        /// <inheritdoc/>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{this.GetType().Name} only supports one-way conversion.");
        }
    }
}
