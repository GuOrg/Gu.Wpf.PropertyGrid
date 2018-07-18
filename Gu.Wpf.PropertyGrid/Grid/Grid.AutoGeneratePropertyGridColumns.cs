namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;

    public static partial class Grid
    {
        // Don't think I'll be using this as it confuses with R# static analysis
        internal static readonly DependencyProperty AutoGeneratePropertyGridColumnsProperty = DependencyProperty.RegisterAttached(
            "AutoGeneratePropertyGridColumns",
            typeof(bool),
            typeof(Grid),
            new FrameworkPropertyMetadata(
                default(bool),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnAutoGeneratePropertyGridColumnsChanged));

        /// <summary>
        /// Helper for setting AutoGeneratePropertyGridColumns property on a Grid.
        /// </summary>
        /// <param name="element">Grid to set AutoGeneratePropertyGridColumns property on.</param>
        /// <param name="value">AutoGeneratePropertyGridColumns property value.</param>
        internal static void SetAutoGeneratePropertyGridColumns(this System.Windows.Controls.Grid element, bool value)
        {
            element.SetValue(AutoGeneratePropertyGridColumnsProperty, value);
        }

        /// <summary>
        /// Helper for reading AutoGeneratePropertyGridColumns property from a Grid.
        /// </summary>
        /// <param name="element">Grid to read AutoGeneratePropertyGridColumns property from.</param>
        /// <returns>AutoGeneratePropertyGridColumns property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        internal static bool GetAutoGeneratePropertyGridColumns(this System.Windows.Controls.Grid element)
        {
            return (bool)element.GetValue(AutoGeneratePropertyGridColumnsProperty);
        }

        private static void OnAutoGeneratePropertyGridColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var grid = (System.Windows.Controls.Grid)d;
                grid.ColumnDefinitions.Clear();
                grid.ColumnDefinitions.Add(CreateColumnDefinition("Header"));
                grid.ColumnDefinitions.Add(CreateColumnDefinition("Value"));
                grid.ColumnDefinitions.Add(CreateColumnDefinition("Suffix"));
            }
            else
            {
                throw new NotSupportedException("Does nolt support removing autogenerated columns, don't think it will ever be useful.");
            }
        }

        private static System.Windows.Controls.ColumnDefinition CreateColumnDefinition(string source)
        {
            var columnDefinition = new System.Windows.Controls.ColumnDefinition();
            ColumnDefinition.SetSource(columnDefinition, source);
            return columnDefinition;
        }
    }
}
