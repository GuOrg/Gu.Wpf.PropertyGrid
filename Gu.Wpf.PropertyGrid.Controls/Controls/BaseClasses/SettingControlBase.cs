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

        public static readonly DependencyProperty ValueWidthProperty = SettingControl.ValueWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(130.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixWidthProperty = SettingControl.SuffixWidthProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(75.0, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            "OldValue",
            typeof(object),
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata
            {
                PropertyChangedCallback = OnOldValueChanged,
                DefaultValue = default(object),
                BindsTwoWayByDefault = false,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        public static readonly DependencyProperty ValueTemplateProperty = DependencyProperty.Register(
            "ValueTemplate",
            typeof(DataTemplate),
            typeof(SettingControlBase),
            new PropertyMetadata(default(DataTemplate)));

        public static readonly DependencyProperty OldValueTemplateProperty = DependencyProperty.Register(
            "OldValueTemplate",
            typeof(DataTemplate),
            typeof(SettingControlBase),
            new PropertyMetadata(default(DataTemplate)));

        public static readonly DependencyProperty ReadOnlyProperty = DependencyProperty.Register(
            "ReadOnly",
            typeof(bool),
            typeof(SettingControlBase),
            new PropertyMetadata(false));

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

        public double ValueWidth
        {
            get { return (double)this.GetValue(ValueWidthProperty); }
            set { this.SetValue(ValueWidthProperty, value); }
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

        public DataTemplate ValueTemplate
        {
            get { return (DataTemplate)this.GetValue(ValueTemplateProperty); }
            set { this.SetValue(ValueTemplateProperty, value); }
        }

        public DataTemplate OldValueTemplate
        {
            get { return (DataTemplate)this.GetValue(OldValueTemplateProperty); }
            set { this.SetValue(OldValueTemplateProperty, value); }
        }

        public double SuffixWidth
        {
            get { return (double)this.GetValue(SuffixWidthProperty); }
            set { this.SetValue(SuffixWidthProperty, value); }
        }

        public bool ReadOnly
        {
            get { return (bool)this.GetValue(ReadOnlyProperty); }
            set { this.SetValue(ReadOnlyProperty, value); }
        }

        public bool? IsDirty
        {
            get { return (bool?)this.GetValue(IsDirtyProperty); }
            protected set { this.SetValue(IsDirtyPropertyKey, value); }
        }

        protected abstract DependencyProperty ValueDependencyProperty { get; }

        protected static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (BindingOperations.GetBinding(o, OldValueProperty) == null)
            {
                return;
            }

            var c = (SettingControlBase)o;
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