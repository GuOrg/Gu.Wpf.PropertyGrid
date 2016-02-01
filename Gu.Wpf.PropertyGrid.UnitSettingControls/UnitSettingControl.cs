namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using Gu.Units;

    public static class UnitSettingControl
    {
        public static readonly Type UnitSettingControlType = typeof(UnitSettingControl<,>);
        public static readonly SymbolFormat DefaultSymbolFormat = SymbolFormat.Default;

        internal static readonly RoutedEvent UnitChangedEvent = EventManager.RegisterRoutedEvent(
            "UnitChanged",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(UnitSettingControl));

        internal static readonly RoutedEventArgs UnitChangedEventArgs = new RoutedEventArgs(UnitChangedEvent);

        public static readonly DependencyProperty SymbolFormatProperty = DependencyProperty.RegisterAttached(
            "SymbolFormat",
            typeof(SymbolFormat),
            typeof(UnitSettingControl),
            new FrameworkPropertyMetadata(DefaultSymbolFormat, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetSymbolFormat(this UIElement element, SymbolFormat value)
        {
            element.SetValue(SymbolFormatProperty, value);
        }

        public static SymbolFormat GetSymbolFormat(this UIElement element)
        {
            return (SymbolFormat)element.GetValue(SymbolFormatProperty);
        }
    }
}