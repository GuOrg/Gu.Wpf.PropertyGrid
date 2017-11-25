namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        /// <summary>
        /// Setting this to true uses the proprty name as header, similar to DataGrid.AutoGenerateColumns.
        /// Not very useful for other things than debug and quick hax
        /// </summary>
        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = DependencyProperty.RegisterAttached(
            "UsePropertyNameAsHeader",
            typeof(bool),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                BooleanBoxes.False,
                FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        /// <summary>
        /// Helper for setting UsePropertyNameAsHeader property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set UsePropertyNameAsHeader property on.</param>
        /// <param name="value">UsePropertyNameAsHeader property value.</param>
        public static void SetUsePropertyNameAsHeader(this UIElement element, bool value)
        {
            element.SetValue(UsePropertyNameAsHeaderProperty, value);
        }

        /// <summary>
        /// Helper for reading UsePropertyNameAsHeader property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read UsePropertyNameAsHeader property from.</param>
        /// <returns>UsePropertyNameAsHeader property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetUsePropertyNameAsHeader(this UIElement element)
        {
            return (bool)element.GetValue(UsePropertyNameAsHeaderProperty);
        }
    }
}