namespace Gu.Wpf.PropertyGrid
{
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class Keys
    {
        public static ResourceKey NestedSettingListStyle { get; } = CreateKey();

        public static ResourceKey ValidationErrorTemplateSelectorKey { get; } = CreateKey();

        public static ResourceKey ValidationErrorRedBorderTemplateKey { get; } = CreateKey();

        public static ResourceKey ValidationErrorTextUnderTemplateKey { get; } = CreateKey();

        private static ComponentResourceKey CreateKey([CallerMemberName] string caller = null)
        {
            // ReSharper disable once AssignNullToNotNullAttribute not null here
            return new ComponentResourceKey(typeof(Keys), caller);
        }
    }
}