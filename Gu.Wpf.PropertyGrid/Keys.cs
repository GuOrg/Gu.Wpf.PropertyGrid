namespace Gu.Wpf.PropertyGrid
{
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class Keys
    {
        public static ResourceKey NestedRowsStyleKey { get; } = CreateKey();

        public static ResourceKey ValidationErrorRedBorderTemplateKey { get; } = CreateKey();

        private static ComponentResourceKey CreateKey([CallerMemberName] string caller = null)
        {
            // ReSharper disable once AssignNullToNotNullAttribute not null here
            return new ComponentResourceKey(typeof(Keys), caller);
        }
    }
}