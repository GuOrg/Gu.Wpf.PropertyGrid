namespace Gu.Wpf.PropertyGrid
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    /// <summary>
    /// A property grid row for arbitrary content.
    /// </summary>
    [DefaultProperty("Content")]
    [ContentProperty("Content")]
    public class ContentRow : Row
    {
        #pragma warning disable SA1202 // Elements must be ordered by access
        /// <summary>Identifies the <see cref="Content"/> dependency property.</summary>
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            nameof(Content),
            typeof(object),
            typeof(ContentRow),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnContentChanged)));

        private static readonly DependencyPropertyKey HasContentPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(HasContent),
            typeof(bool),
            typeof(ContentRow),
            new PropertyMetadata(BooleanBoxes.False));

        /// <summary>Identifies the <see cref="HasContent"/> dependency property.</summary>
        public static readonly DependencyProperty HasContentProperty = HasContentPropertyKey.DependencyProperty;

        /// <summary>Identifies the <see cref="ContentTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty ContentTemplateProperty = DependencyProperty.Register(
            nameof(ContentTemplate),
            typeof(DataTemplate),
            typeof(ContentRow),
            new PropertyMetadata(default(DataTemplate), (d, e) => ((ContentRow)d).OnContentTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue)));

        /// <summary>Identifies the <see cref="ContentTemplateSelector"/> dependency property.</summary>
        public static readonly DependencyProperty ContentTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ContentTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(ContentRow),
            new PropertyMetadata(default(DataTemplateSelector), (d, e) => ((ContentRow)d).OnContentTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue)));

        /// <summary>Identifies the <see cref="ContentStringFormat"/> dependency property.</summary>
        public static readonly DependencyProperty ContentStringFormatProperty = DependencyProperty.Register(
            nameof(ContentStringFormat),
            typeof(string),
            typeof(ContentRow),
            new PropertyMetadata(default(string), (d, e) => ((ContentRow)d).OnContentStringFormatChanged((string)e.OldValue, (string)e.NewValue)));
#pragma warning restore SA1202 // Elements must be ordered by access

        static ContentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(typeof(ContentRow)));
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="Content"/> is non-null, false otherwise.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        public bool HasContent => (bool)this.GetValue(HasContentProperty);

        /// <summary>
        /// Gets or sets the data used to for the Content of each item in the control.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        [Localizability(LocalizationCategory.Label)]
        public object Content
        {
            get => (string)this.GetValue(ContentProperty);
            set => this.SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display the <seealso cref="Content"/>.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplate ContentTemplate
        {
            get => (DataTemplate)this.GetValue(ContentTemplateProperty);
            set => this.SetValue(ContentTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplateSelector"/> used to display the <seealso cref="Content"/>.
        /// </summary>
        /// <remarks>
        /// This property is ignored if <seealso cref="ContentTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector ContentTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ContentTemplateSelectorProperty);
            set => this.SetValue(ContentTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the format used to display the Content content as a string.
        /// This arises only when no template is available.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public string ContentStringFormat
        {
            get => (string)this.GetValue(ContentStringFormatProperty);
            set => this.SetValue(ContentStringFormatProperty, value);
        }

        /// <summary>This method is invoked when the <see cref="ContentProperty"/> changes.</summary>
        /// <param name="oldValue">The old value of <see cref="ContentProperty"/>.</param>
        /// <param name="newValue">The new value of <see cref="ContentProperty"/>.</param>
        protected virtual void OnContentChanged(object oldValue, object newValue)
        {
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <summary>This method is invoked when the <see cref="ContentTemplateProperty"/> changes.</summary>
        /// <param name="oldValue">The old value of <see cref="ContentTemplateProperty"/>.</param>
        /// <param name="newValue">The new value of <see cref="ContentTemplateProperty"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnContentTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }

        /// <summary>This method is invoked when the <see cref="ContentTemplateSelectorProperty"/> changes.</summary>
        /// <param name="oldValue">The old value of <see cref="ContentTemplateSelectorProperty"/>.</param>
        /// <param name="newValue">The new value of <see cref="ContentTemplateSelectorProperty"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnContentTemplateSelectorChanged(DataTemplateSelector oldValue, DataTemplateSelector newValue)
        {
        }

        /// <summary>This method is invoked when the <see cref="ContentStringFormatProperty"/> changes.</summary>
        /// <param name="oldValue">The old value of <see cref="ContentStringFormatProperty"/>.</param>
        /// <param name="newValue">The new value of <see cref="ContentStringFormatProperty"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnContentStringFormatChanged(string oldValue, string newValue)
        {
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ContentRow)d;
            row.SetValue(HasContentPropertyKey, (e.NewValue != null) ? BooleanBoxes.True : BooleanBoxes.False);
            row.OnContentChanged(e.OldValue, e.NewValue);
        }
    }
}
