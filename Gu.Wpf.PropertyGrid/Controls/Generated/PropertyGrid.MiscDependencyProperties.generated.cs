#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.RegisterAttached(
            "IsReadOnly",
            typeof(bool),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStringFormatProperty = DependencyProperty.RegisterAttached(
            "OldValueStringFormat",
            typeof(string),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldDataContextProperty = DependencyProperty.RegisterAttached(
            "OldDataContext",
            typeof(object),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits));


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

        public static void SetOldValueStringFormat(this UIElement element, string value)
        {
            element.SetValue(OldValueStringFormatProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static string GetOldValueStringFormat(this UIElement element)
        {
            return (string)element.GetValue(OldValueStringFormatProperty);
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
    }

    public abstract partial class Row
    {
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStringFormatProperty = PropertyGrid.OldValueStringFormatProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits,
                OnOldDataContextChanged));


        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }

        public string OldValueStringFormat
        {
            get { return (string)this.GetValue(OldValueStringFormatProperty); }
            set { this.SetValue(OldValueStringFormatProperty, value); }
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }
    }

    public partial class Rows
    {
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStringFormatProperty = PropertyGrid.OldValueStringFormatProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits,
                OnOldDataContextChanged));


        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }

        public string OldValueStringFormat
        {
            get { return (string)this.GetValue(OldValueStringFormatProperty); }
            set { this.SetValue(OldValueStringFormatProperty, value); }
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }
    }

    public partial class ContentRow
    {
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStringFormatProperty = PropertyGrid.OldValueStringFormatProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits,
                OnOldDataContextChanged));


        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }

        public string OldValueStringFormat
        {
            get { return (string)this.GetValue(OldValueStringFormatProperty); }
            set { this.SetValue(OldValueStringFormatProperty, value); }
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }
    }
}
