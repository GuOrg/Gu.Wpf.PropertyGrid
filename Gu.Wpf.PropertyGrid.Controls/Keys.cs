using System.Runtime.CompilerServices;
using System.Windows;

namespace Gu.PropertyGrid
{
    public static class Keys
    {
        public static ResourceKey ItemsControlSettingListStyle { get; } = CreateKey();

        public static ResourceKey ItemsControlNestedSettingListStyle { get; } = CreateKey();

        public static ResourceKey NestedSettingListStyle { get; } = CreateKey();
        
        public static ResourceKey HeaderTextBlockStyleKey { get; } = CreateKey();

        public static ResourceKey RowStyleKey { get; } = CreateKey();

        public static ResourceKey RowTemplateKey { get; } = CreateKey();

        public static ResourceKey PropertyGridStyleKey { get; } = CreateKey();


        private static ComponentResourceKey CreateKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Keys), caller); ;
        }
    }
}