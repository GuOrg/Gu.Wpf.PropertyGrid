using System.Windows;

namespace Gu.PropertyGrid
{
    public static class SettingControl
    {
        public static readonly DependencyProperty ValueWidthProperty = DependencyProperty.RegisterAttached(
            "ValueWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(130.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixWidth",
            typeof (double),
            typeof (SettingControl),
            new FrameworkPropertyMetadata(75.0, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetValueWidth(this UIElement element, double value)
        {
            element.SetValue(ValueWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueWidthProperty);
        }

        public static void SetSuffixWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixWidthProperty);
        }
    }
}