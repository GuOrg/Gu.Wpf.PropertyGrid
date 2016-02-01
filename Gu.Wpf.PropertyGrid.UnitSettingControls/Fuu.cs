namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class Fuu : RelativeSource
    {
        public Fuu()
        {
            this.Mode = RelativeSourceMode.TemplatedParent;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValue = base.ProvideValue(serviceProvider);
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var binding = (Binding)provideValueTarget.TargetObject;
            return new Fuuuu(serviceProvider, binding);
        }

        private class Fuuuu : IValueConverter
        {
            private Binding binding;
            private IServiceProvider serviceProvider;

            public Fuuuu(IServiceProvider serviceProvider, Binding binding)
            {
                this.serviceProvider = serviceProvider;
                this.binding = binding;
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
