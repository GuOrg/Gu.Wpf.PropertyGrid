namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class SettingsControl : ItemsControl
    {
        public static readonly DependencyProperty HeaderWidthProperty = DependencyProperty.Register(
            nameof(HeaderWidth),
            typeof(GridLength),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(GridLength.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty HeaderMinWidthProperty = DependencyProperty.Register(
            nameof(HeaderMinWidth),
            typeof(double),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty HeaderMaxWidthProperty = DependencyProperty.Register(
            nameof(HeaderMaxWidth),
            typeof(double),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty ValueWidthProperty = DependencyProperty.Register(
            nameof(ValueWidth),
            typeof(GridLength),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(GridLength.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty ValueMinWidthProperty = DependencyProperty.Register(
            nameof(ValueMinWidth),
            typeof(double),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty ValueMaxWidthProperty = DependencyProperty.Register(
            nameof(ValueMaxWidth),
            typeof(double),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty SuffixWidthProperty = DependencyProperty.Register(
            nameof(SuffixWidth),
            typeof(GridLength),
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(GridLength.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty SuffixMinWidthProperty = DependencyProperty.Register(
                nameof(SuffixMinWidth),
                typeof(double),
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty SuffixMaxWidthProperty = DependencyProperty.Register(
                nameof(SuffixMaxWidth),
                typeof(double),
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = SettingControl.UsePropertyNameAsHeaderProperty.AddOwner(
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(
                    BooleanBoxes.False,
                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        public static readonly DependencyProperty OldDataContextProperty = SettingControl.OldDataContextProperty.AddOwner(
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty IsReadOnlyProperty = SettingControl.IsReadOnlyProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = SettingControl.InfoPresenterStyleProperty.AddOwner(
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        static SettingsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsControl), new FrameworkPropertyMetadata(typeof(SettingsControl)));
            FocusableProperty.OverrideMetadata(typeof(SettingsControl), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

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

        public bool UsePropertyNameAsHeader
        {
            get { return (bool)this.GetValue(UsePropertyNameAsHeaderProperty); }
            set { this.SetValue(UsePropertyNameAsHeaderProperty, value); }
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }

        public Style InfoPresenterStyle
        {
            get { return (Style)this.GetValue(InfoPresenterStyleProperty); }
            set { this.SetValue(InfoPresenterStyleProperty, value); }
        }

        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }
    }
}
