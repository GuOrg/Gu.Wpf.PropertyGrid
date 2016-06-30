namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using Gu.Units;

    public static class UnitRow
    {
        public static readonly SymbolFormat DefaultSymbolFormat = SymbolFormat.Default;

        public static readonly DependencyProperty SymbolFormatProperty = DependencyProperty.RegisterAttached(
            "SymbolFormat",
            typeof(SymbolFormat),
            typeof(UnitRow),
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