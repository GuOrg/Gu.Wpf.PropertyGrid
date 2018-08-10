namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// Attached properties for <see cref="System.Windows.Controls.ColumnDefinition"/>
    /// </summary>
    public static class ColumnDefinition
    {
        /// <summary>
        /// Attached property for setting Width, MinWidth, MaxWidth and SharedSizeGroup for a <see cref="System.Windows.Controls.ColumnDefinition"/>
        /// Similar to <see cref="ContentPresenter.ContentSource"/>
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached(
            "Source",
            typeof(string),
            typeof(ColumnDefinition),
            new PropertyMetadata(
                default(string),
                OnSourceChanged),
            ValidateSource);

        private static readonly PropertyPaths HeaderPropertyPaths = new PropertyPaths("Header", SharedSizeGroups.HeaderColumn);
        private static readonly PropertyPaths ValuePropertyPaths = new PropertyPaths("Value", SharedSizeGroups.ValueColumn);
        private static readonly PropertyPaths SuffixPropertyPaths = new PropertyPaths("Suffix", SharedSizeGroups.SuffixColumn);

        /// <summary>Helper for setting <see cref="SourceProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.ColumnDefinition"/> to set <see cref="SourceProperty"/> on.</param>
        /// <param name="value">Source property value.</param>
        public static void SetSource(this System.Windows.Controls.ColumnDefinition element, string value)
        {
            element.SetValue(SourceProperty, value);
        }

        /// <summary>Helper for getting <see cref="SourceProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.ColumnDefinition"/> to read <see cref="SourceProperty"/> from.</param>
        /// <returns>Source property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.ColumnDefinition))]
        public static string GetSource(this System.Windows.Controls.ColumnDefinition element)
        {
            return (string)element.GetValue(SourceProperty);
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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

            var parent = GetParentOrDefault<Row>(grid) ??
                         GetParentOrDefault<ContentRow>(grid) ??
                         GetParentOrDefault<Rows>(grid);

            if (parent == null)
            {
                if (DesignerProperties.GetIsInDesignMode(d))
                {
                    throw new NotSupportedException($"Cannot use {typeof(ColumnDefinition).Name}.{SourceProperty.Name} when not in a {typeof(Row).Name}");
                }

                return;
            }

            var paths = GetPropertyPaths(source);

            _ = d.Bind(System.Windows.Controls.ColumnDefinition.WidthProperty)
                 .OneWayTo(parent, paths.WidthPath);

            _ = d.Bind(System.Windows.Controls.ColumnDefinition.MaxWidthProperty)
                 .OneWayTo(parent, paths.MaxWidthPath);

            _ = d.Bind(System.Windows.Controls.ColumnDefinition.MinWidthProperty)
                 .OneWayTo(parent, paths.MinWidthPath);

            _ = d.Bind(System.Windows.Controls.DefinitionBase.SharedSizeGroupProperty)
                 .OneWayTo(parent, paths.WidthPath, paths.SharedSizeGroupConverter);
        }

        private static Control GetParentOrDefault<T>(System.Windows.Controls.Grid grid)
            where T : Control
        {
            return grid.Ancestors()
                       .OfType<T>()
                       .FirstOrDefault();
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

        private static bool ValidateSource(object value)
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
#pragma warning disable SA1401 // Fields must be private
            internal readonly PropertyPath WidthPath;
            internal readonly PropertyPath MinWidthPath;
            internal readonly PropertyPath MaxWidthPath;
            internal readonly IValueConverter SharedSizeGroupConverter;
#pragma warning restore SA1401 // Fields must be private

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

            private class SharedSizeGroupConverter_ : IValueConverter
            {
                private readonly string groupName;

                public SharedSizeGroupConverter_(string groupName)
                {
                    this.groupName = groupName;
                }

                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    return (GridLength)value == GridLength.Auto ? this.groupName : null;
                }

                object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotSupportedException($"{nameof(SharedSizeGroupConverter_)} can only be used in OneWay bindings");
                }
            }
        }
    }
}
