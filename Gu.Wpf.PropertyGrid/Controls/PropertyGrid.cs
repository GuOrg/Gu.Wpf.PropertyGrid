namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = DependencyProperty.RegisterAttached(
            "UsePropertyNameAsHeader",
            typeof(bool),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                BooleanBoxes.False,
                FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        public static void SetUsePropertyNameAsHeader(this UIElement element, bool value)
        {
            element.SetValue(UsePropertyNameAsHeaderProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetUsePropertyNameAsHeader(this UIElement element)
        {
            return (bool)element.GetValue(UsePropertyNameAsHeaderProperty);
        }
    }
}