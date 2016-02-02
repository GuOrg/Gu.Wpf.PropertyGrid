namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static class Grid
    {
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

        private static void OnRowDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            var rowDefinitions = (RowDefinitions)e.NewValue;
            if (rowDefinitions == null)
            {
                return;
            }

            foreach (var rowDefinition in rowDefinitions)
            {
                grid.RowDefinitions.Add(rowDefinition);
            }
        }

        private static void OnColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            var columnDefinitions = (ColumnDefinitions)e.NewValue;
            if (columnDefinitions == null)
            {
                return;
            }

            foreach (var columnDefinition in columnDefinitions)
            {
                grid.ColumnDefinitions.Add(columnDefinition);
            }
        }
    }
}
