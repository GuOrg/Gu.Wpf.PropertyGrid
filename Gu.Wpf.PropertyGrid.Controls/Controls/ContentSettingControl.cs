namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class ContentSettingControl : HeaderedContentControl
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

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }
    }
}