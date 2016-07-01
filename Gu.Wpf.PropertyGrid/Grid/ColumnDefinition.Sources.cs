namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    public static class ColumnDefinition
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached(
            "Source",
            typeof(string),
            typeof(ColumnDefinition),
            new PropertyMetadata(
                default(string),
                OnColumnDefinitionSourceChanged),
            OnValidateColumnDefinitionSource);

        private static readonly PropertyPaths HeaderPropertyPaths = new PropertyPaths("Header", SharedSizeGroups.HeaderColumn);
        private static readonly PropertyPaths ValuePropertyPaths = new PropertyPaths("Value", SharedSizeGroups.ValueColumn);
        private static readonly PropertyPaths SuffixPropertyPaths = new PropertyPaths("Suffix", SharedSizeGroups.SuffixColumn);

        public static void SetSource(this System.Windows.Controls.ColumnDefinition element, string value)
        {
            element.SetValue(SourceProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.ColumnDefinition))]
        public static string GetSource(this System.Windows.Controls.ColumnDefinition element)
        {
            return (string)element.GetValue(SourceProperty);
        }

        private static void OnColumnDefinitionSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = e.NewValue as string;
            if (string.IsNullOrWhiteSpace(source))
            {
                return;
            }

            var grid = ((System.Windows.Controls.ColumnDefinition)d).Parent as System.Windows.Controls.Grid;
            if (grid == null)
            {
                if (DesignerProperties.GetIsInDesignMode(d))
                {
                    throw new NotSupportedException($"Cannot use {typeof(ColumnDefinition).Name}.{SourceProperty.Name} when not in a {typeof(Grid).Name}");
                }

                return;
            }

            var parent = (System.Windows.Controls.Control)grid.Ancestors()
                          .OfType<Row>()
                          .FirstOrDefault() ??
                      grid.Ancestors()
                          .OfType<Rows>()
                          .FirstOrDefault();
            if (parent != null)
            {
                var paths = GetPropertyPaths(source);

                d.Bind(System.Windows.Controls.ColumnDefinition.WidthProperty)
                 .OneWayTo(parent, paths.WidthPath);

                d.Bind(System.Windows.Controls.ColumnDefinition.MaxWidthProperty)
                 .OneWayTo(parent, paths.MaxWidthPath);

                d.Bind(System.Windows.Controls.ColumnDefinition.MinWidthProperty)
                 .OneWayTo(parent, paths.MinWidthPath);

                d.Bind(System.Windows.Controls.DefinitionBase.SharedSizeGroupProperty)
                 .OneWayTo(parent, paths.WidthPath, paths.SharedSizeGroupConverter);
            }
            else
            {
                if (DesignerProperties.GetIsInDesignMode(d))
                {
                    throw new NotSupportedException($"Cannot use {typeof(ColumnDefinition).Name}.{SourceProperty.Name} when not in a {typeof(Row).Name}");
                }
            }
        }

        private static PropertyPaths GetPropertyPaths(string source)
        {
            switch (source)
            {
                case "Header":
                    return HeaderPropertyPaths;
                case "Value":
                    return ValuePropertyPaths;
                case "Suffix":
                    return SuffixPropertyPaths;
                default:
                    throw new ArgumentOutOfRangeException(nameof(source));
            }
        }

        private static bool OnValidateColumnDefinitionSource(object value)
        {
            if (value == null)
            {
                return true;
            }

            var source = value as string;
            if (source == "Header" || source == "Value" || source == "Suffix")
            {
                return true;
            }

            return false;
        }

        private class PropertyPaths
        {
            internal readonly PropertyPath WidthPath;
            internal readonly PropertyPath MinWidthPath;
            internal readonly PropertyPath MaxWidthPath;
            internal readonly IValueConverter SharedSizeGroupConverter;

            public PropertyPaths(string source, string sharedSizeGroup)
            {
                this.WidthPath = CreatePath(source + "Width");
                this.MinWidthPath = CreatePath(source + "MinWidth");
                this.MaxWidthPath = CreatePath(source + "MaxWidth");
                this.SharedSizeGroupConverter = new SharedSizeGroupConverter_(sharedSizeGroup);
            }

            private static PropertyPath CreatePath(string property)
            {
                Debug.Assert(typeof(Row).GetProperty(property) != null, $"Row does not have property: {property}");
                Debug.Assert(typeof(Rows).GetProperty(property) != null, $"Rows does not have property: {property}");
                var path = new PropertyPath(property);
                return path;
            }

            private class SharedSizeGroupConverter_: IValueConverter
            {
                private readonly string groupName;

                public SharedSizeGroupConverter_(string groupName)
                {
                    this.groupName = groupName;
                }

                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    var gridLength = (GridLength)value;
                    if (gridLength == GridLength.Auto)
                    {
                        return this.groupName;
                    }

                    return null;
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}