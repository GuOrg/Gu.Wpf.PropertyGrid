namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;

    public class ValidationErrorToStringConverter : IValueConverter
    {
        public static readonly ValidationErrorToStringConverter Default = new ValidationErrorToStringConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
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
            throw new NotSupportedException($"{this.GetType().Name} only supports one-way conversion.");
        }
    }
}