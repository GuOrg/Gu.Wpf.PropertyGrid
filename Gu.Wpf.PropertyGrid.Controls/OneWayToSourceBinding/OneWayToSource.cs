namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    public static class OneWayToSource
    {
        public static readonly DependencyProperty BindProperty = DependencyProperty.RegisterAttached(
            "Bind",
            typeof(ProxyBinding),
            typeof(OneWayToSource),
            new PropertyMetadata(default(Paths), OnBindChanged));

        public static void SetBind(this UIElement element, ProxyBinding value)
        {
            element.SetValue(BindProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static ProxyBinding GetBind(this UIElement element)
        {
            return (ProxyBinding)element.GetValue(BindProperty);
        }

        private static void OnBindChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ProxyBinding)e.OldValue)?.Dispose();
        }

        public class ProxyBinding : DependencyObject, IDisposable
        {
            private static readonly DependencyProperty SourceProxyProperty = DependencyProperty.Register(
                "SourceProxy",
                typeof(object),
                typeof(ProxyBinding),
                new PropertyMetadata(default(object), OnSourceProxyChanged));

            private static readonly DependencyProperty TargetProxyProperty = DependencyProperty.Register(
                "TargetProxy",
                typeof(object),
                typeof(ProxyBinding),
                new PropertyMetadata(default(object)));

            public ProxyBinding(DependencyObject source, DependencyProperty sourceProperty, string targetProperty)
            {
                var sourceBinding = new Binding
                {
                    Path = new PropertyPath(sourceProperty),
                    Source = source,
                    Mode = BindingMode.OneWay,
                };

                BindingOperations.SetBinding(this, SourceProxyProperty, sourceBinding);

                var targetBinding = new Binding()
                {
                    Path = new PropertyPath($"{nameof(FrameworkElement.DataContext)}.{targetProperty}"),
                    Mode = BindingMode.OneWayToSource,
                    Source = source
                };

                BindingOperations.SetBinding(this, TargetProxyProperty, targetBinding);
            }

            public void Dispose()
            {
                BindingOperations.ClearAllBindings(this);
            }

            private static void OnSourceProxyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                d.SetCurrentValue(TargetProxyProperty, e.NewValue);
            }
        }
    }

    [MarkupExtensionReturnType(typeof(OneWayToSource.ProxyBinding))]
    public class Paths : MarkupExtension
    {
        public DependencyProperty From { get; set; }

        public string To { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var targetObject = (UIElement)provideValueTarget.TargetObject;
            return new OneWayToSource.ProxyBinding(targetObject, this.From, this.To);
        }
    }
}
