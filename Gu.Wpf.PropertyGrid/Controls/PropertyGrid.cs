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

        /// <summary>
        /// Helper for setting IsReadOnly property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set IsReadOnly property on.</param>
        /// <param name="value">IsReadOnly property value.</param>
        public static void SetIsReadOnly(this UIElement element, bool value)
        {
            element.SetValue(IsReadOnlyProperty, value);
        }

        /// <summary>
        /// Helper for reading IsReadOnly property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read IsReadOnly property from.</param>
        /// <returns>IsReadOnly property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetIsReadOnly(this UIElement element)
        {
            return (bool)element.GetValue(IsReadOnlyProperty);
        }

        /// <summary>
        /// Helper for setting OldDataContext property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set OldDataContext property on.</param>
        /// <param name="value">OldDataContext property value.</param>
        public static void SetOldDataContext(this UIElement element, object value)
        {
            element.SetValue(OldDataContextProperty, value);
        }

        /// <summary>
        /// Helper for reading OldDataContext property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read OldDataContext property from.</param>
        /// <returns>OldDataContext property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static object GetOldDataContext(this UIElement element)
        {
            return (object)element.GetValue(OldDataContextProperty);
        }

        /// <summary>
        /// Helper for setting OldValueStringFormat property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set OldValueStringFormat property on.</param>
        /// <param name="value">OldValueStringFormat property value.</param>
        public static void SetOldValueStringFormat(this UIElement element, string value)
        {
            element.SetValue(OldValueStringFormatProperty, value);
        }

        /// <summary>
        /// Helper for reading OldValueStringFormat property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read OldValueStringFormat property from.</param>
        /// <returns>OldValueStringFormat property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static string GetOldValueStringFormat(this UIElement element)
        {
            return (string)element.GetValue(OldValueStringFormatProperty);
        }
    }
}
