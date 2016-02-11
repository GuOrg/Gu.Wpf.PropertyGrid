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
    public class ValidationErrorToStringConverter : MarkupExtension, IValueConverter
    {
        public static readonly ValidationErrorToStringConverter Default = new ValidationErrorToStringConverter();

        public ValidationErrorToStringConverter()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var text = value as string;
            if (text != null)
            {
                return text;
            }

            var result = value as ValidationResult;
            if (result != null)
            {
                return this.Convert(result.ErrorContent, targetType, parameter, culture);
            }

            var error = value as ValidationError;
            if (error != null)
            {
                return this.Convert(error.ErrorContent, targetType, parameter, culture);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(ValidationErrorToStringConverter)} only supports one-way conversion.");
        }
    }
}