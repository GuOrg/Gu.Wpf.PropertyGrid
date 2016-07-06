namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public partial class ContentRow : HeaderedContentControl
    {
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

        static ContentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(typeof(ContentRow)));
            FocusableProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(false));
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

        protected virtual void UpdateTemplate()
        {
            this.ControlTemplateSelector?.UpdateCurrentTemplate(this);
        }

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }

        protected virtual void OnOldDataContextChanged(object oldValue, object newValue)
        {
        }

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ContentRow)d;
            if (row.IsLoaded)
            {
                row.OnOldDataContextChanged(e.OldValue, e.NewValue);
            }
            else
            {
                d.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => row.OnOldDataContextChanged(e.OldValue, e.NewValue)));
            }
        }
    }
}