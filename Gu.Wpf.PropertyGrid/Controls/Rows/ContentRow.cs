namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    /// <summary>
    /// A property grid row for arbitrary content.
    /// </summary>
    public partial class ContentRow : HeaderedContentControl
    {
        /// <summary>Identifies the <see cref="Suffix"/> dependency property.</summary>
        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            nameof(Suffix),
            typeof(object),
            typeof(ContentRow),
            new PropertyMetadata(default(object)));

        /// <summary>Identifies the <see cref="OldValue"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            nameof(OldValue),
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
            get => this.GetValue(SuffixProperty);
            set => this.SetValue(SuffixProperty, value);
        }

        public object OldValue
        {
            get => this.GetValue(OldValueProperty);
            set => this.SetValue(OldValueProperty, value);
        }

        protected virtual void UpdateTemplate()
        {
            this.ControlTemplateSelector?.UpdateCurrentTemplate(this);
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
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
                _ = d.Dispatcher.BeginInvoke(
                     DispatcherPriority.Loaded,
                     new Action(() => row.OnOldDataContextChanged(e.OldValue, e.NewValue)));
            }
        }
    }
}
