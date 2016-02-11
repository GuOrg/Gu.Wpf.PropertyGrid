namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class SettingsControl : ItemsControl
    {
        public static readonly DependencyProperty ValueMinWidthProperty = SettingControl.ValueMinWidthProperty.AddOwner(
                typeof(SettingsControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMaxWidthProperty = SettingControl.ValueMaxWidthProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = SettingControl.SuffixMinWidthProperty.AddOwner(
             typeof(SettingsControl),
             new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMaxWidthProperty = SettingControl.SuffixMaxWidthProperty.AddOwner(
             typeof(SettingsControl),
             new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));

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

        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = SettingControl.ValueStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

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

        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
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
