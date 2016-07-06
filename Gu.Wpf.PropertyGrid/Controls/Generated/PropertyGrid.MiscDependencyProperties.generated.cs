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
                "Old value: {0}",
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
                "Old value: {0}",
                FrameworkPropertyMetadataOptions.Inherits));


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
                "Old value: {0}",
                FrameworkPropertyMetadataOptions.Inherits));


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
                "Old value: {0}",
                FrameworkPropertyMetadataOptions.Inherits));


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
    }
}
