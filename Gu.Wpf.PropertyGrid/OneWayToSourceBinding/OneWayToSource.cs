namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    public static class OneWayToSource
    {
        public static readonly DependencyProperty BindProperty = DependencyProperty.RegisterAttached(
            "Bind",
            typeof(ProxyBinding),
            typeof(OneWayToSource),
            new PropertyMetadata(
                default(ProxyBinding),
                (d, e) => ((ProxyBinding)e.OldValue)?.Dispose()));

        /// <summary>Helper for setting <see cref="BindProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="BindProperty"/> on.</param>
        /// <param name="value">Bind property value.</param>
        public static void SetBind(this UIElement element, ProxyBinding value)
        {
            element.SetValue(BindProperty, value);
        }

        /// <summary>Helper for getting <see cref="BindProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="BindProperty"/> from.</param>
        /// <returns>Bind property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static ProxyBinding GetBind(this UIElement element)
        {
            return (ProxyBinding)element.GetValue(BindProperty);
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

                _ = BindingOperations.SetBinding(this, SourceProxyProperty, sourceBinding);

                var targetBinding = new Binding()
                {
                    Path = new PropertyPath($"{nameof(FrameworkElement.DataContext)}.{targetProperty}"),
                    Mode = BindingMode.OneWayToSource,
                    Source = source
                };

                _ = BindingOperations.SetBinding(this, TargetProxyProperty, targetBinding);
            }

            /// <inheritdoc />
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
}
