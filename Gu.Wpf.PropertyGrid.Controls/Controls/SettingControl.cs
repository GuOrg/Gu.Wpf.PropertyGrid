namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class SettingControl
    {
        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = DependencyProperty.RegisterAttached(
            "UsePropertyNameAsHeader",
            typeof(bool),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                BooleanBoxes.False,
                FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        public static readonly DependencyProperty OldDataContextProperty = DependencyProperty.RegisterAttached(
            "OldDataContext",
            typeof(object),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.RegisterAttached(
            "IsReadOnly",
            typeof(bool),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

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

        public static void SetOldDataContext(this UIElement element, object value)
        {
            element.SetValue(OldDataContextProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static object GetOldDataContext(this UIElement element)
        {
            return (object)element.GetValue(OldDataContextProperty);
        }

        public static void SetIsReadOnly(this UIElement element, bool value)
        {
            element.SetValue(IsReadOnlyProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetIsReadOnly(this UIElement element)
        {
            return (bool)element.GetValue(IsReadOnlyProperty);
        }
    }
}