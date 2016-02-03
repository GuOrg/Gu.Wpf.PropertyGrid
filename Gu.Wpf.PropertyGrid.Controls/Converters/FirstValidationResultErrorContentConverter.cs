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
    public class FirstValidationResultErrorContentConverter : MarkupExtension, IValueConverter
    {
        public static readonly FirstValidationResultErrorContentConverter Default = new FirstValidationResultErrorContentConverter();

        public FirstValidationResultErrorContentConverter()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = value as IEnumerable<object>;
            if (enumerable != null)
            {
                value = enumerable.FirstOrDefault();
            }

            if (value == null)
            {
                return null;
            }

            var error = value as ValidationError;

            if (error != null)
            {
                return error.ErrorContent;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(FirstValidationResultErrorContentConverter)} only supports one-way conversion.");
        }
    }
}