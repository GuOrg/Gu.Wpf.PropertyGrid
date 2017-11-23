namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(OneWayToSource.ProxyBinding))]
    public class Paths : MarkupExtension
    {
        public DependencyProperty From { get; set; }

        public string To { get; set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var targetObject = (UIElement)provideValueTarget.TargetObject;
            return new OneWayToSource.ProxyBinding(targetObject, this.From, this.To);
        }
    }
}