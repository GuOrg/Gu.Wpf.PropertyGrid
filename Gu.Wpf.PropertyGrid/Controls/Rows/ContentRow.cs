namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class ContentRow : HeaderedContentControl
    {
        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(object),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            "Suffix",
            typeof(object),
            typeof(ContentRow),
            new PropertyMetadata(default(object)));

        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            "OldValue",
            typeof(object),
            typeof(ContentRow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(BooleanBoxes.False, FrameworkPropertyMetadataOptions.Inherits));

        static ContentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(typeof(ContentRow)));
            FocusableProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(false));
        }

        public object OldDataContext
        {
            get { return (object)this.GetValue(OldDataContextProperty); }
            set { this.SetValue(OldDataContextProperty, value); }
        }

        public object Suffix
        {
            get { return this.GetValue(SuffixProperty); }
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

        protected virtual void UpdateTemplate()
        {
            this.ControlTemplateSelector?.UpdateCurrentTemplate(this);
        }

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }
    }
}