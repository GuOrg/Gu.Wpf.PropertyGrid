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
            new PropertyMetadata(default(ProxyBinding), OnBindChanged));

        /// <summary>
        /// Helper for setting Bind property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set Bind property on.</param>
        /// <param name="value">Bind property value.</param>
        public static void SetBind(this UIElement element, ProxyBinding value)
        {
            element.SetValue(BindProperty, value);
        }

        /// <summary>
        /// Helper for reading Bind property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read Bind property from.</param>
        /// <returns>Bind property value.</returns>
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
}
