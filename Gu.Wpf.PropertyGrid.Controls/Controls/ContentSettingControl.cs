namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class ContentSettingControl : HeaderedContentControl
    {
        public static readonly DependencyProperty OldDataContextProperty = SettingControl.OldDataContextProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(
                default(object),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            "Suffix",
            typeof(string),
            typeof(ContentSettingControl),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            "OldValue",
            typeof(object),
            typeof(ContentSettingControl),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsReadOnlyProperty = SettingControl.IsReadOnlyProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ContentStyleProperty = DependencyProperty.Register(
            "ContentStyle",
            typeof(Style),
            typeof(ContentSettingControl),
            new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = SettingControl.InfoPresenterStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        static ContentSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentSettingControl), new FrameworkPropertyMetadata(typeof(ContentSettingControl)));
            FocusableProperty.OverrideMetadata(typeof(ContentSettingControl), new FrameworkPropertyMetadata(false));
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }

        public string Suffix
        {
            get { return (string)this.GetValue(SuffixProperty); }
            set { this.SetValue(SuffixProperty, value); }
        }

        public object OldValue
        {
            get { return (object)this.GetValue(OldValueProperty); }
            set { this.SetValue(OldValueProperty, value); }
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

        public Style ContentStyle
        {
            get { return (Style)this.GetValue(ContentStyleProperty); }
            set { this.SetValue(ContentStyleProperty, value); }
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

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }
    }
}