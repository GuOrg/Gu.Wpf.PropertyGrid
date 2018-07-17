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
    }
}
