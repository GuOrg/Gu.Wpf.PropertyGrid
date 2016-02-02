namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public static class Grid
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

        public static void SetCell(UIElement element, GridCell value)
        {
            element.SetValue(CellProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridCell GetCell(UIElement element)
        {
            return (GridCell)element.GetValue(CellProperty);
        }

        public static void SetRowDefinitions(System.Windows.Controls.Grid element, RowDefinitions value)
        {
            element.SetValue(RowDefinitionsProperty, value);
        }

        public static RowDefinitions GetRowDefinitions(System.Windows.Controls.Grid element)
        {
            return (RowDefinitions)element.GetValue(RowDefinitionsProperty);
        }

        public static void SetColumnDefinitions(System.Windows.Controls.Grid element, ColumnDefinitions value)
        {
            element.SetValue(ColumnDefinitionsProperty, value);
        }

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

            d.SetValue(System.Windows.Controls.Grid.RowProperty, cell.Row);
            d.SetValue(System.Windows.Controls.Grid.ColumnProperty, cell.Column);
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
