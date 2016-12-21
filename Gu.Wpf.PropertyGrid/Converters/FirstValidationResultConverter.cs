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
    public class FirstValidationResultConverter : MarkupExtension, IValueConverter
    {
        public static readonly FirstValidationResultConverter Default = new FirstValidationResultConverter();

        // ReSharper disable once EmptyConstructor think the xaml parse needs it
        public FirstValidationResultConverter()
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
            throw new NotSupportedException($"{nameof(FirstValidationResultConverter)} only supports one-way conversion.");
        }
    }
}
