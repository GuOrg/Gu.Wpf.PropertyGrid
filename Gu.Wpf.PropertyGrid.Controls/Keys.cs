using System.Runtime.CompilerServices;
using System.Windows;

namespace Gu.Wpf.PropertyGrid
{
    public static class Keys
    {
        public static ResourceKey ItemsControlSettingListStyleKey { get; } = CreateKey();

        public static ResourceKey ItemsControlNestedSettingListStyleKey { get; } = CreateKey();

        public static ResourceKey NestedSettingListStyle { get; } = CreateKey();

        public static ResourceKey SettingRowBaseStyle { get; } = CreateKey();

        public static ResourceKey UnitSettingBaseStyleKey { get; } = CreateKey();

        public static ResourceKey SettingRowHeaderStyleKey { get; } = CreateKey();

        public static ResourceKey SettingRowValueStyle { get; } = CreateKey();

        public static ResourceKey SettingRowUnitValueStyleKey { get; } = CreateKey();

        public static ResourceKey SettingRowOldValueStyle { get; } = CreateKey();

        public static ResourceKey SettingRowErrorStyleKey { get; } = CreateKey();

        public static ResourceKey SettingRowSuffixStyleKey { get; } = CreateKey();

        private static ComponentResourceKey CreateKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Keys), caller);
        }
    }
}