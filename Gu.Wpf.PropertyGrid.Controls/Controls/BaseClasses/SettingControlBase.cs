namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    public abstract class SettingControlBase : Control
    {
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
            new PropertyMetadata(null, OnOldValueChanged));

        public static readonly DependencyProperty IsReadOnlyProperty = SettingControl.IsReadOnlyProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = SettingControl.ValueStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueMinWidthProperty = SettingControl.ValueMinWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixMinWidthProperty = SettingControl.SuffixMinWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        private static readonly DependencyPropertyKey IsDirtyPropertyKey = DependencyProperty.RegisterReadOnly(
            "IsDirty",
            typeof(bool?),
            typeof(SettingControlBase),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsDirtyProperty = IsDirtyPropertyKey.DependencyProperty;

        static SettingControlBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingControlBase), new FrameworkPropertyMetadata(typeof(SettingControlBase)));
            FocusableProperty.OverrideMetadata(typeof(SettingControlBase), new FrameworkPropertyMetadata(false));
        }

        public string Header
        {
            get { return (string)this.GetValue(HeaderProperty); }
            set { this.SetValue(HeaderProperty, value); }
        }

        public double ValueMinWidth
        {
            get { return (double)this.GetValue(ValueMinWidthProperty); }
            set { this.SetValue(ValueMinWidthProperty, value); }
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

        public double SuffixMinWidth
        {
            get { return (double)this.GetValue(SuffixMinWidthProperty); }
            set { this.SetValue(SuffixMinWidthProperty, value); }
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

        public bool? IsDirty
        {
            get { return (bool?)this.GetValue(IsDirtyProperty); }
            protected set { this.SetValue(IsDirtyPropertyKey, value); }
        }

        protected abstract DependencyProperty ValueDependencyProperty { get; }

        protected virtual void OnValueChanged(object oldValue, object newValue)
        {
        }

        protected static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var c = (SettingControlBase)o;
            c.OnValueChanged(e.OldValue, e.NewValue);
            if (BindingOperations.GetBinding(o, OldValueProperty) == null)
            {
                return;
            }

            c.IsDirty = !Equals(c.OldValue, e.NewValue);
        }

        private static void OnOldValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var sc = (SettingControlBase)o;
            var value = sc.GetValue(sc.ValueDependencyProperty);
            sc.IsDirty = !Equals(sc.OldValue, value);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            //var valueBinding = BindingOperations.GetBinding(this, this.ValueDependencyProperty);
            //if (valueBinding != null)
            //{
            //    var oldValueBinding = BindingOperations.GetBinding(this, OldValueProperty);
            //    if (oldValueBinding != null)
            //    {
            //        return;
            //    }

            //    var editableCopyName = nameof(SettingsViewModel<INotifyPropertyChanged, ISettingsRepository>.EditableCopy);
            //    if (!valueBinding.Path.Path.Contains(editableCopyName))
            //    {
            //        return;
            //    }

            //    var lastSavedCopyName = nameof(SettingsViewModel<INotifyPropertyChanged, ISettingsRepository>.LastSavedCopy);

            //    var path = valueBinding.Path.Path.Replace(editableCopyName, lastSavedCopyName);
            //    oldValueBinding = new Binding(path)
            //    {
            //        Mode = BindingMode.OneWay,
            //        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //    };

            //    BindingOperations.SetBinding(this, OldValueProperty, oldValueBinding);
            //}
        }
    }
}