namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [TypeConverter(typeof(QuantityBindingExtensionConverter))]
    [MarkupExtensionReturnType(typeof(BindingExpression))]
    public class QuantityBindingExtension : MarkupExtension
    {
        private static readonly Dictionary<string, PropertyPath> NamePathMap = new Dictionary<string, PropertyPath>();
        private string property;

        public QuantityBindingExtension()
        {
        }

        public QuantityBindingExtension(string property)
        {
            this.Property = property;
        }

        [ConstructorArgument("property")]
        public string Property
        {
            get
            {
                return this.property;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (typeof(UnitSettingControl<,>).GetProperty(value) == null)
                {
                    throw new ArgumentException($"Did not find property {value} on {typeof(UnitSettingControl<,>)}");
                }

                this.property = value;
            }
        }

        public PropertyPath Path
        {
            get
            {
                PropertyPath path;
                if (NamePathMap.TryGetValue(this.Property, out path))
                {
                    return path;
                }

                path = new PropertyPath(this.Property);
                NamePathMap[this.Property] = path;
                return path;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var targetObject = provideValueTarget.TargetObject;
            if (targetObject.GetType().Name.EndsWith("SharedDp"))
            {
                return this;
            }

            var paramater = new Paramater();
            var binding = new Binding
            {
                Path = this.Path,
                RelativeSource = RelativeSource.TemplatedParent,
                Converter = UnitConverter.Default,
                ConverterParameter = paramater
            };

            var expression = (BindingExpression)binding.ProvideValue(serviceProvider);
            paramater.Expression = expression;
            return expression;
        }

        private class Paramater
        {
            public BindingExpression Expression { get; set; }
        }

        private class UnitConverter : IValueConverter
        {
            public static readonly UnitConverter Default = new UnitConverter();

            private UnitConverter()
            {
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
}
