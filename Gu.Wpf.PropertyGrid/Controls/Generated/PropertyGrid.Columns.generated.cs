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

        /// <summary>
        /// Helper for setting HeaderWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set HeaderWidth property on.</param>
        /// <param name="value">HeaderWidth property value.</param>
        public static void SetHeaderWidth(this UIElement element, GridLength value)
        {
            element.SetValue(HeaderWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading HeaderWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read HeaderWidth property from.</param>
        /// <returns>HeaderWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetHeaderWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(HeaderWidthProperty);
        }

        /// <summary>
        /// Helper for setting HeaderMinWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set HeaderMinWidth property on.</param>
        /// <param name="value">HeaderMinWidth property value.</param>
        public static void SetHeaderMinWidth(this UIElement element, double value)
        {
            element.SetValue(HeaderMinWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading HeaderMinWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read HeaderMinWidth property from.</param>
        /// <returns>HeaderMinWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetHeaderMinWidth(this UIElement element)
        {
            return (double)element.GetValue(HeaderMinWidthProperty);
        }

        /// <summary>
        /// Helper for setting HeaderMaxWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set HeaderMaxWidth property on.</param>
        /// <param name="value">HeaderMaxWidth property value.</param>
        public static void SetHeaderMaxWidth(this UIElement element, double value)
        {
            element.SetValue(HeaderMaxWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading HeaderMaxWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read HeaderMaxWidth property from.</param>
        /// <returns>HeaderMaxWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetHeaderMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(HeaderMaxWidthProperty);
        }

        /// <summary>
        /// Helper for setting ValueWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set ValueWidth property on.</param>
        /// <param name="value">ValueWidth property value.</param>
        public static void SetValueWidth(this UIElement element, GridLength value)
        {
            element.SetValue(ValueWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading ValueWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read ValueWidth property from.</param>
        /// <returns>ValueWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetValueWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(ValueWidthProperty);
        }

        /// <summary>
        /// Helper for setting ValueMinWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set ValueMinWidth property on.</param>
        /// <param name="value">ValueMinWidth property value.</param>
        public static void SetValueMinWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMinWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading ValueMinWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read ValueMinWidth property from.</param>
        /// <returns>ValueMinWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMinWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMinWidthProperty);
        }

        /// <summary>
        /// Helper for setting ValueMaxWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set ValueMaxWidth property on.</param>
        /// <param name="value">ValueMaxWidth property value.</param>
        public static void SetValueMaxWidth(this UIElement element, double value)
        {
            element.SetValue(ValueMaxWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading ValueMaxWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read ValueMaxWidth property from.</param>
        /// <returns>ValueMaxWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetValueMaxWidth(this UIElement element)
        {
            return (double)element.GetValue(ValueMaxWidthProperty);
        }

        /// <summary>
        /// Helper for setting SuffixWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set SuffixWidth property on.</param>
        /// <param name="value">SuffixWidth property value.</param>
        public static void SetSuffixWidth(this UIElement element, GridLength value)
        {
            element.SetValue(SuffixWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading SuffixWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read SuffixWidth property from.</param>
        /// <returns>SuffixWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridLength GetSuffixWidth(this UIElement element)
        {
            return (GridLength)element.GetValue(SuffixWidthProperty);
        }

        /// <summary>
        /// Helper for setting SuffixMinWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set SuffixMinWidth property on.</param>
        /// <param name="value">SuffixMinWidth property value.</param>
        public static void SetSuffixMinWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMinWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading SuffixMinWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read SuffixMinWidth property from.</param>
        /// <returns>SuffixMinWidth property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static double GetSuffixMinWidth(this UIElement element)
        {
            return (double)element.GetValue(SuffixMinWidthProperty);
        }

        /// <summary>
        /// Helper for setting SuffixMaxWidth property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set SuffixMaxWidth property on.</param>
        /// <param name="value">SuffixMaxWidth property value.</param>
        public static void SetSuffixMaxWidth(this UIElement element, double value)
        {
            element.SetValue(SuffixMaxWidthProperty, value);
        }

        /// <summary>
        /// Helper for reading SuffixMaxWidth property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read SuffixMaxWidth property from.</param>
        /// <returns>SuffixMaxWidth property value.</returns>
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
