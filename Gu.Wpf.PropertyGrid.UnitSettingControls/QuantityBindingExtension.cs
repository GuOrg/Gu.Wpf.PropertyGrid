namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    using Gu.Units;

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

            var paramater = new Parameter();
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

        private class Parameter
        {
            internal static readonly DependencyProperty ParametersProperty = DependencyProperty.RegisterAttached(
                "Parameters",
                typeof(IList),
                typeof(Parameter),
                new PropertyMetadata(default(IList)));

            static Parameter()
            {
                EventManager.RegisterClassHandler(typeof(SettingControlBase), UnitSettingControl.UnitChangedEvent, new RoutedEventHandler(OnUnitChanged));
            }

            public BindingExpression Expression { get; set; }

            private static void OnUnitChanged(object sender, RoutedEventArgs e)
            {
                var settingControl = (SettingControlBase) sender;
                var parameters = (IReadOnlyList<Parameter>)settingControl.GetValue(ParametersProperty);
                if (parameters == null)
                {
                    return;
                }

                foreach (var parameter in parameters)
                {
                    parameter.Expression.UpdateTarget();
                }
            }
        }

        private class UnitConverter : IValueConverter
        {
            public static readonly UnitConverter Default = new UnitConverter();

            private UnitConverter()
            {
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                {
                    return null;
                }

                var converter = GetConverter(parameter);
                return converter.GetScalarValue((IQuantity)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var converter = GetConverter(parameter);
                var d = System.Convert.ToDouble(value, culture);
                return converter.GetQuantityValue(d);
            }

            private static IQuantityScalarConverter GetConverter(object parameter)
            {
                var paramater = (Parameter)parameter;
                var source = (SettingControlBase)paramater.Expression.ResolvedSource;
                var parameters = (List<Parameter>)source.GetValue(Parameter.ParametersProperty);
                if (parameters == null)
                {
                    parameters = new List<Parameter>();
                    source.SetValue(Parameter.ParametersProperty, parameters);
                }

                if (!parameters.Contains(paramater))
                {
                    parameters.Add(paramater);
                }

                var converter = (IQuantityScalarConverter)source;
                return converter;
            }
        }
    }
}
