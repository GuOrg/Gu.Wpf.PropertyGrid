namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        /// <summary> Gets or sets a value indicating whether the row is read only. </summary>
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.RegisterAttached(
            "IsReadOnly",
            typeof(bool),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary> Gets or sets the data context with old values. </summary>
        public static readonly DependencyProperty OldDataContextProperty = DependencyProperty.RegisterAttached(
            "OldDataContext",
            typeof(object),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary> Gets or sets the string format for the old value. </summary>
        public static readonly DependencyProperty OldValueStringFormatProperty = DependencyProperty.RegisterAttached(
            "OldValueStringFormat",
            typeof(string),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                "Old value: {0}",
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Helper for setting <see cref="IsReadOnlyProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="IsReadOnlyProperty"/> on.</param>
        /// <param name="value">IsReadOnly property value.</param>
        public static void SetIsReadOnly(this UIElement element, bool value)
        {
            element.SetValue(IsReadOnlyProperty, value);
        }

        /// <summary>Helper for getting <see cref="IsReadOnlyProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="IsReadOnlyProperty"/> from.</param>
        /// <returns>IsReadOnly property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetIsReadOnly(this UIElement element)
        {
            return (bool)element.GetValue(IsReadOnlyProperty);
        }

        /// <summary>Helper for setting <see cref="OldDataContextProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="OldDataContextProperty"/> on.</param>
        /// <param name="value">OldDataContext property value.</param>
        public static void SetOldDataContext(this UIElement element, object value)
        {
            element.SetValue(OldDataContextProperty, value);
        }

        /// <summary>Helper for getting <see cref="OldDataContextProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="OldDataContextProperty"/> from.</param>
        /// <returns>OldDataContext property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static object GetOldDataContext(this UIElement element)
        {
            return (object)element.GetValue(OldDataContextProperty);
        }

        /// <summary>Helper for setting <see cref="OldValueStringFormatProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="OldValueStringFormatProperty"/> on.</param>
        /// <param name="value">OldValueStringFormat property value.</param>
        public static void SetOldValueStringFormat(this UIElement element, string value)
        {
            element.SetValue(OldValueStringFormatProperty, value);
        }

        /// <summary>Helper for getting <see cref="OldValueStringFormatProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="OldValueStringFormatProperty"/> from.</param>
        /// <returns>OldValueStringFormat property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static string GetOldValueStringFormat(this UIElement element)
        {
            return (string)element.GetValue(OldValueStringFormatProperty);
        }
    }
}
