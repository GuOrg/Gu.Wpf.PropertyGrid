namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows.Markup;

    internal static class ServiceProviderExt
    {
        internal static IProvideValueTarget ProvideValueTarget(this IServiceProvider provider)
        {
            return (IProvideValueTarget)provider.GetService(typeof(IProvideValueTarget));
        }
    }
}
