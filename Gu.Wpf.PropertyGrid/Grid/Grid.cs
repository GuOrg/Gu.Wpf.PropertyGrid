namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public static partial class Grid
    {
        public static readonly DependencyProperty CellProperty = DependencyProperty.RegisterAttached(
            "Cell",
            typeof(GridCell),
            typeof(Grid),
            new PropertyMetadata(default(GridCell), OnCellChanged));

        public static readonly DependencyProperty RowDefinitionsProperty = DependencyProperty.RegisterAttached(
            "RowDefinitions",
            typeof(RowDefinitions),
            typeof(Grid),
            new FrameworkPropertyMetadata(
                default(RowDefinitions),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnRowDefinitionsChanged));

        public static readonly DependencyProperty ColumnDefinitionsProperty = DependencyProperty.RegisterAttached(
            "ColumnDefinitions",
            typeof(ColumnDefinitions),
            typeof(Grid),
            new FrameworkPropertyMetadata(
                default(ColumnDefinitions),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnColumnDefinitionsChanged));

        private static readonly DependencyProperty IsAutoProperty = DependencyProperty.RegisterAttached(
            "IsAuto",
            typeof(bool),
            typeof(Grid),
            new PropertyMetadata(BooleanBoxes.False));

        /// <summary>
        /// Helper for setting Cell property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set Cell property on.</param>
        /// <param name="value">Cell property value.</param>
        public static void SetCell(UIElement element, GridCell value)
        {
            element.SetValue(CellProperty, value);
        }

        /// <summary>
        /// Helper for reading Cell property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read Cell property from.</param>
        /// <returns>Cell property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridCell GetCell(UIElement element)
        {
            return (GridCell)element.GetValue(CellProperty);
        }

        /// <summary>
        /// Helper for setting RowDefinitions property on a Grid.
        /// </summary>
        /// <param name="element">Grid to set RowDefinitions property on.</param>
        /// <param name="value">RowDefinitions property value.</param>
        public static void SetRowDefinitions(System.Windows.Controls.Grid element, RowDefinitions value)
        {
            element.SetValue(RowDefinitionsProperty, value);
        }

        /// <summary>
        /// Helper for reading RowDefinitions property from a Grid.
        /// </summary>
        /// <param name="element">Grid to read RowDefinitions property from.</param>
        /// <returns>RowDefinitions property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static RowDefinitions GetRowDefinitions(System.Windows.Controls.Grid element)
        {
            return (RowDefinitions)element.GetValue(RowDefinitionsProperty);
        }

        /// <summary>
        /// Helper for setting ColumnDefinitions property on a Grid.
        /// </summary>
        /// <param name="element">Grid to set ColumnDefinitions property on.</param>
        /// <param name="value">ColumnDefinitions property value.</param>
        public static void SetColumnDefinitions(System.Windows.Controls.Grid element, ColumnDefinitions value)
        {
            element.SetValue(ColumnDefinitionsProperty, value);
        }

        /// <summary>
        /// Helper for reading ColumnDefinitions property from a Grid.
        /// </summary>
        /// <param name="element">Grid to read ColumnDefinitions property from.</param>
        /// <returns>ColumnDefinitions property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static ColumnDefinitions GetColumnDefinitions(System.Windows.Controls.Grid element)
        {
            return (ColumnDefinitions)element.GetValue(ColumnDefinitionsProperty);
        }

        private static void SetIsAuto(this DefinitionBase element, bool value)
        {
            element.SetValue(IsAutoProperty, BooleanBoxes.Box(value));
        }

        private static bool GetIsAuto(this DefinitionBase element)
        {
            return (bool)element.GetValue(IsAutoProperty);
        }

        private static void OnCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cell = (GridCell)e.NewValue;
            if (cell == null)
            {
                // ??
                return;
            }

            d.SetCurrentValue(System.Windows.Controls.Grid.RowProperty, cell.Row);
            d.SetCurrentValue(System.Windows.Controls.Grid.ColumnProperty, cell.Column);
        }

        private static void OnRowDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            grid.RowDefinitions.RemoveAllAuto();

            var rowDefinitions = (RowDefinitions)e.NewValue;
            if (rowDefinitions == null)
            {
                return;
            }

            foreach (var rowDefinition in rowDefinitions)
            {
                rowDefinition.SetIsAuto(true);
                grid.RowDefinitions.Add(rowDefinition);
            }
        }

        private static void OnColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            grid.ColumnDefinitions.RemoveAllAuto();

            var columnDefinitions = (ColumnDefinitions)e.NewValue;
            if (columnDefinitions == null)
            {
                return;
            }

            foreach (var columnDefinition in columnDefinitions)
            {
                columnDefinition.SetIsAuto(true);
                grid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        private static void RemoveAllAuto<T>(this IList<T> definitions)
            where T : DefinitionBase
        {
            for (int i = definitions.Count - 1; i >= 0; i--)
            {
                if (Equals(definitions[i].GetIsAuto(), BooleanBoxes.True))
                {
                    definitions.RemoveAt(i);
                }
            }
        }
    }
}
