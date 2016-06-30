#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class SettingControl
    {
        public static readonly DependencyProperty HeaderWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderWidth",
            typeof(GridLength),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMinWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderMinWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMaxWidthProperty = DependencyProperty.RegisterAttached(
            "HeaderMaxWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueWidthProperty = DependencyProperty.RegisterAttached(
            "ValueWidth",
            typeof(GridLength),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMinWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = DependencyProperty.RegisterAttached(
            "ValueMaxWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixWidth",
            typeof(GridLength),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMinWidth",
            typeof(double),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = DependencyProperty.RegisterAttached(
            "SuffixMaxWidth",
            typeof(double),
            typeof(SettingControl),
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

    public abstract partial class SettingControlBase
    {
        public static readonly DependencyProperty HeaderWidthProperty = SettingControl.HeaderWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMinWidthProperty = SettingControl.HeaderMinWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMaxWidthProperty = SettingControl.HeaderMaxWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueWidthProperty = SettingControl.ValueWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = SettingControl.ValueMinWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = SettingControl.ValueMaxWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = SettingControl.SuffixWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = SettingControl.SuffixMinWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = SettingControl.SuffixMaxWidthProperty.AddOwner(
            typeof(SettingControlBase),
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

    public partial class SettingsControl
    {
        public static readonly DependencyProperty HeaderWidthProperty = SettingControl.HeaderWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMinWidthProperty = SettingControl.HeaderMinWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMaxWidthProperty = SettingControl.HeaderMaxWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueWidthProperty = SettingControl.ValueWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = SettingControl.ValueMinWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = SettingControl.ValueMaxWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = SettingControl.SuffixWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = SettingControl.SuffixMinWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = SettingControl.SuffixMaxWidthProperty.AddOwner(
            typeof(SettingsControl),
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

    public partial class ContentSettingControl
    {
        public static readonly DependencyProperty HeaderWidthProperty = SettingControl.HeaderWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMinWidthProperty = SettingControl.HeaderMinWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderMaxWidthProperty = SettingControl.HeaderMaxWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueWidthProperty = SettingControl.ValueWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = SettingControl.ValueMinWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = SettingControl.ValueMaxWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                double.PositiveInfinity,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = SettingControl.SuffixWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                GridLength.Auto,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = SettingControl.SuffixMinWidthProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = SettingControl.SuffixMaxWidthProperty.AddOwner(
            typeof(ContentSettingControl),
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

