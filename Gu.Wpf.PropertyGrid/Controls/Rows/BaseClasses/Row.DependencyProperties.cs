namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public abstract partial class Row
    {
#pragma warning disable SA1202 // Elements must be ordered by access

        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty = PropertyGrid.UsePropertyNameAsHeaderProperty.AddOwner(
                typeof(Row),
                new FrameworkPropertyMetadata(
                    BooleanBoxes.False,
                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        public static readonly DependencyProperty ControlTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ControlTemplateSelector),
            typeof(RowControlTemplateSelector),
            typeof(Row),
            new PropertyMetadata(default(RowControlTemplateSelector)));

        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
                typeof(Row),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.Inherits, OnOldDataContextChanged));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header",
            typeof(string),
            typeof(Row),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            "Suffix",
            typeof(string),
            typeof(Row),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            "OldValue",
            typeof(object),
            typeof(Row),
            new PropertyMetadata(new object(), OnOldValueChanged));

        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        private static readonly DependencyPropertyKey IsDirtyPropertyKey = DependencyProperty.RegisterReadOnly(
            "IsDirty",
            typeof(bool?),
            typeof(Row),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsDirtyProperty = IsDirtyPropertyKey.DependencyProperty;
#pragma warning restore SA1202 // Elements must be ordered by access

        static Row()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(typeof(Row)));
            FocusableProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        public bool UsePropertyNameAsHeader
        {
            get { return (bool)this.GetValue(UsePropertyNameAsHeaderProperty); }
            set { this.SetValue(UsePropertyNameAsHeaderProperty, BooleanBoxes.Box(value)); }
        }

        public RowControlTemplateSelector ControlTemplateSelector
        {
            get { return (RowControlTemplateSelector)this.GetValue(ControlTemplateSelectorProperty); }
            set { this.SetValue(ControlTemplateSelectorProperty, value); }
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
