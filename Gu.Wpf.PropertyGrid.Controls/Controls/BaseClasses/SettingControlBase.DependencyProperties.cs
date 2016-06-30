namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public abstract partial class SettingControlBase
    {
#pragma warning disable SA1202 // Elements must be ordered by access

        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = SettingControl.UsePropertyNameAsHeaderProperty.AddOwner(
                typeof(SettingControlBase),
                new FrameworkPropertyMetadata(
                    BooleanBoxes.False,
                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        public static readonly DependencyProperty OldDataContextProperty = SettingControl.OldDataContextProperty.AddOwner(
                typeof(SettingControlBase),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.Inherits, OnOldDataContextChanged));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header",
            typeof(string),
            typeof(SettingControlBase),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            "Suffix",
            typeof(string),
            typeof(SettingControlBase),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            "OldValue",
            typeof(object),
            typeof(SettingControlBase),
            new PropertyMetadata(new object(), OnOldValueChanged));

        public static readonly DependencyProperty IsReadOnlyProperty = SettingControl.IsReadOnlyProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        private static readonly DependencyPropertyKey IsDirtyPropertyKey = DependencyProperty.RegisterReadOnly(
            "IsDirty",
            typeof(bool?),
            typeof(SettingControlBase),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsDirtyProperty = IsDirtyPropertyKey.DependencyProperty;
#pragma warning restore SA1202 // Elements must be ordered by access

        static SettingControlBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingControlBase), new FrameworkPropertyMetadata(typeof(SettingControlBase)));
            FocusableProperty.OverrideMetadata(typeof(SettingControlBase), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        public bool UsePropertyNameAsHeader
        {
            get { return (bool)this.GetValue(UsePropertyNameAsHeaderProperty); }
            set { this.SetValue(UsePropertyNameAsHeaderProperty, BooleanBoxes.Box(value)); }
        }

        public object OldDataContext
        {
            get { return this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }

        public string Header
        {
            get { return (string)this.GetValue(HeaderProperty); }
            set { this.SetValue(HeaderProperty, value); }
        }

        public string Suffix
        {
            get { return (string)this.GetValue(SuffixProperty); }
            set { this.SetValue(SuffixProperty, value); }
        }

        public object OldValue
        {
            get { return this.GetValue(OldValueProperty); }
            set { this.SetValue(OldValueProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, BooleanBoxes.Box(value)); }
        }

        public bool? IsDirty
        {
            get { return (bool?)this.GetValue(IsDirtyProperty); }
            protected set { this.SetValue(IsDirtyPropertyKey, value); }
        }
    }
}
