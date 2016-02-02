namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static class SettingControl
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

        public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.RegisterAttached(
            "HeaderStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = DependencyProperty.RegisterAttached(
            "ValueStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = DependencyProperty.RegisterAttached(
            "SuffixStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = DependencyProperty.RegisterAttached(
            "InfoPresenterStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = DependencyProperty.RegisterAttached(
            "OldValueStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = DependencyProperty.RegisterAttached(
            "ErrorStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.RegisterAttached(
            "IsReadOnly",
            typeof(bool),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMaxWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMinWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMinWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMaxWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));

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

        public static void SetHeaderStyle(this UIElement element, Style value)
        {
            element.SetValue(HeaderStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetHeaderStyle(this UIElement element)
        {
            return (Style)element.GetValue(HeaderStyleProperty);
        }

        public static void SetValueStyle(this UIElement element, Style value)
        {
            element.SetValue(ValueStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(ValueStyleProperty);
        }

        public static void SetSuffixStyle(this UIElement element, Style value)
        {
            element.SetValue(SuffixStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetSuffixStyle(this UIElement element)
        {
            return (Style)element.GetValue(SuffixStyleProperty);
        }

        public static void SetInfoPresenterStyle(this UIElement element, Style value)
        {
            element.SetValue(InfoPresenterStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetInfoPresenterStyle(this UIElement element)
        {
            return (Style)element.GetValue(InfoPresenterStyleProperty);
        }

        public static void SetOldValueStyle(this UIElement element, Style value)
        {
            element.SetValue(OldValueStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetOldValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(OldValueStyleProperty);
        }

        public static void SetErrorStyle(this UIElement element, Style value)
        {
            element.SetValue(ErrorStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetErrorStyle(this UIElement element)
        {
            return (Style)element.GetValue(ErrorStyleProperty);
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

        public static void SetValueMinWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMinWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMinWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMinWidthProperty);
        }

        public static void SetValueMaxWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMaxWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMaxWidthProperty);
        }

        public static void SetSuffixMinWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMinWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixMinWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixMinWidthProperty);
        }

        public static void SetSuffixMaxWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMaxWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixMaxWidthProperty);
        }
    }
}