#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        /// <summary>Identifies the HeaderWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderWidth",
            typeof(GridLength),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMinWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderMinWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMaxWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderMaxWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueWidthProperty = DependencyProperty.RegisterAttached(
            "ValueWidth",
            typeof(GridLength),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMinWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMinWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMaxWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMaxWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixWidth",
            typeof(GridLength),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMinWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMinWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMaxWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMaxWidth",
            typeof(double),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHeaderWidth(this UIElement element, GridLength value)
        {
            element.SetValue(HeaderWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetHeaderWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(HeaderWidthProperty);
        }

        public static void SetHeaderMinWidth(this UIElement element, double value)
        {
            element.SetValue(HeaderMinWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetHeaderMinWidth(this UIElement element)
        {
            return (double)element.GetValue(HeaderMinWidthProperty);
        }

        public static void SetHeaderMaxWidth(this UIElement element, double value)
        {
            element.SetValue(HeaderMaxWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetHeaderMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(HeaderMaxWidthProperty);
        }

        public static void SetValueWidth(this UIElement element, GridLength value)
        {
            element.SetValue(ValueWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetValueWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(ValueWidthProperty);
        }

        public static void SetValueMinWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMinWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMinWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMinWidthProperty);
        }

        public static void SetValueMaxWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMaxWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMaxWidthProperty);
        }

        public static void SetSuffixWidth(this UIElement element, GridLength value)
        {
            element.SetValue(SuffixWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetSuffixWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(SuffixWidthProperty);
        }

        public static void SetSuffixMinWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMinWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixMinWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixMinWidthProperty);
        }

        public static void SetSuffixMaxWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMaxWidthProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixMaxWidthProperty);
        }
    }

    public partial class Rows
    {
        /// <summary>Identifies the HeaderWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderWidthProperty = PropertyGrid.HeaderWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMinWidthProperty = PropertyGrid.HeaderMinWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMaxWidthProperty = PropertyGrid.HeaderMaxWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueWidthProperty = PropertyGrid.ValueWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMinWidthProperty = PropertyGrid.ValueMinWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMaxWidthProperty = PropertyGrid.ValueMaxWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixWidthProperty = PropertyGrid.SuffixWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMinWidthProperty = PropertyGrid.SuffixMinWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMaxWidthProperty = PropertyGrid.SuffixMaxWidthProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public GridLength HeaderWidth
        {
            get { return (GridLength)this.GetValue(HeaderWidthProperty); }
            set { this.SetValue(HeaderWidthProperty, value); }
        }

        public double HeaderMinWidth
        {
            get { return (double)this.GetValue(HeaderMinWidthProperty); }
            set { this.SetValue(HeaderMinWidthProperty, value); }
        }

        public double HeaderMaxWidth
        {
            get { return (double)this.GetValue(HeaderMaxWidthProperty); }
            set { this.SetValue(HeaderMaxWidthProperty, value); }
        }

        public GridLength ValueWidth
        {
            get { return (GridLength)this.GetValue(ValueWidthProperty); }
            set { this.SetValue(ValueWidthProperty, value); }
        }

        public double ValueMinWidth
        {
            get { return (double)this.GetValue(ValueMinWidthProperty); }
            set { this.SetValue(ValueMinWidthProperty, value); }
        }

        public double ValueMaxWidth
        {
            get { return (double)this.GetValue(ValueMaxWidthProperty); }
            set { this.SetValue(ValueMaxWidthProperty, value); }
        }

        public GridLength SuffixWidth
        {
            get { return (GridLength)this.GetValue(SuffixWidthProperty); }
            set { this.SetValue(SuffixWidthProperty, value); }
        }

        public double SuffixMinWidth
        {
            get { return (double)this.GetValue(SuffixMinWidthProperty); }
            set { this.SetValue(SuffixMinWidthProperty, value); }
        }

        public double SuffixMaxWidth
        {
            get { return (double)this.GetValue(SuffixMaxWidthProperty); }
            set { this.SetValue(SuffixMaxWidthProperty, value); }
        }
    }

    public abstract partial class Row
    {
        /// <summary>Identifies the HeaderWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderWidthProperty = PropertyGrid.HeaderWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMinWidthProperty = PropertyGrid.HeaderMinWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMaxWidthProperty = PropertyGrid.HeaderMaxWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueWidthProperty = PropertyGrid.ValueWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMinWidthProperty = PropertyGrid.ValueMinWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMaxWidthProperty = PropertyGrid.ValueMaxWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixWidthProperty = PropertyGrid.SuffixWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMinWidthProperty = PropertyGrid.SuffixMinWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMaxWidthProperty = PropertyGrid.SuffixMaxWidthProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public GridLength HeaderWidth
        {
            get { return (GridLength)this.GetValue(HeaderWidthProperty); }
            set { this.SetValue(HeaderWidthProperty, value); }
        }

        public double HeaderMinWidth
        {
            get { return (double)this.GetValue(HeaderMinWidthProperty); }
            set { this.SetValue(HeaderMinWidthProperty, value); }
        }

        public double HeaderMaxWidth
        {
            get { return (double)this.GetValue(HeaderMaxWidthProperty); }
            set { this.SetValue(HeaderMaxWidthProperty, value); }
        }

        public GridLength ValueWidth
        {
            get { return (GridLength)this.GetValue(ValueWidthProperty); }
            set { this.SetValue(ValueWidthProperty, value); }
        }

        public double ValueMinWidth
        {
            get { return (double)this.GetValue(ValueMinWidthProperty); }
            set { this.SetValue(ValueMinWidthProperty, value); }
        }

        public double ValueMaxWidth
        {
            get { return (double)this.GetValue(ValueMaxWidthProperty); }
            set { this.SetValue(ValueMaxWidthProperty, value); }
        }

        public GridLength SuffixWidth
        {
            get { return (GridLength)this.GetValue(SuffixWidthProperty); }
            set { this.SetValue(SuffixWidthProperty, value); }
        }

        public double SuffixMinWidth
        {
            get { return (double)this.GetValue(SuffixMinWidthProperty); }
            set { this.SetValue(SuffixMinWidthProperty, value); }
        }

        public double SuffixMaxWidth
        {
            get { return (double)this.GetValue(SuffixMaxWidthProperty); }
            set { this.SetValue(SuffixMaxWidthProperty, value); }
        }
    }

    public partial class ContentRow
    {
        /// <summary>Identifies the HeaderWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderWidthProperty = PropertyGrid.HeaderWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMinWidthProperty = PropertyGrid.HeaderMinWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the HeaderMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty HeaderMaxWidthProperty = PropertyGrid.HeaderMaxWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueWidthProperty = PropertyGrid.ValueWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMinWidthProperty = PropertyGrid.ValueMinWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty ValueMaxWidthProperty = PropertyGrid.ValueMaxWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixWidthProperty = PropertyGrid.SuffixWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMinWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMinWidthProperty = PropertyGrid.SuffixMinWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixMaxWidth attached dependency property.</summary>
        public static readonly DependencyProperty SuffixMaxWidthProperty = PropertyGrid.SuffixMaxWidthProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public GridLength HeaderWidth
        {
            get { return (GridLength)this.GetValue(HeaderWidthProperty); }
            set { this.SetValue(HeaderWidthProperty, value); }
        }

        public double HeaderMinWidth
        {
            get { return (double)this.GetValue(HeaderMinWidthProperty); }
            set { this.SetValue(HeaderMinWidthProperty, value); }
        }

        public double HeaderMaxWidth
        {
            get { return (double)this.GetValue(HeaderMaxWidthProperty); }
            set { this.SetValue(HeaderMaxWidthProperty, value); }
        }

        public GridLength ValueWidth
        {
            get { return (GridLength)this.GetValue(ValueWidthProperty); }
            set { this.SetValue(ValueWidthProperty, value); }
        }

        public double ValueMinWidth
        {
            get { return (double)this.GetValue(ValueMinWidthProperty); }
            set { this.SetValue(ValueMinWidthProperty, value); }
        }

        public double ValueMaxWidth
        {
            get { return (double)this.GetValue(ValueMaxWidthProperty); }
            set { this.SetValue(ValueMaxWidthProperty, value); }
        }

        public GridLength SuffixWidth
        {
            get { return (GridLength)this.GetValue(SuffixWidthProperty); }
            set { this.SetValue(SuffixWidthProperty, value); }
        }

        public double SuffixMinWidth
        {
            get { return (double)this.GetValue(SuffixMinWidthProperty); }
            set { this.SetValue(SuffixMinWidthProperty, value); }
        }

        public double SuffixMaxWidth
        {
            get { return (double)this.GetValue(SuffixMaxWidthProperty); }
            set { this.SetValue(SuffixMaxWidthProperty, value); }
        }
    }
}
