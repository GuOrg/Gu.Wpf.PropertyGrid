namespace Gu.Wpf.PropertyGrid
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    public abstract partial class Row
    {
#pragma warning disable SA1202 // Elements must be ordered by access
        /// <summary>Identifies the <see cref="Header"/> dependency property.</summary>
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            nameof(Header),
            typeof(object),
            typeof(Row),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnHeaderChanged)));

        private static readonly DependencyPropertyKey HasHeaderPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(HasHeader),
            typeof(bool),
            typeof(Row),
            new PropertyMetadata(BooleanBoxes.False));

        /// <summary>Identifies the <see cref="HasHeader"/> dependency property.</summary>
        public static readonly DependencyProperty HasHeaderProperty = HasHeaderPropertyKey.DependencyProperty;

        /// <summary>Identifies the <see cref="HeaderTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(
            nameof(HeaderTemplate),
            typeof(DataTemplate),
            typeof(Row),
            new PropertyMetadata(default(DataTemplate), (d, e) => ((Row)d).OnHeaderTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue)));

        /// <summary>Identifies the <see cref="HeaderTemplateSelector"/> dependency property.</summary>
        public static readonly DependencyProperty HeaderTemplateSelectorProperty = DependencyProperty.Register(
            nameof(HeaderTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(Row),
            new PropertyMetadata(default(DataTemplateSelector), (d, e) => ((Row)d).OnHeaderTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue)));

        /// <summary>Identifies the <see cref="HeaderStringFormat"/> dependency property.</summary>
        public static readonly DependencyProperty HeaderStringFormatProperty = DependencyProperty.Register(
            nameof(HeaderStringFormat),
            typeof(string),
            typeof(Row),
            new PropertyMetadata(default(string), (d, e) => ((Row)d).OnHeaderStringFormatChanged((string)e.OldValue, (string)e.NewValue)));

#pragma warning restore SA1202 // Elements must be ordered by access

        /// <summary>
        /// True if Header is non-null, false otherwise.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        public bool HasHeader => (bool)this.GetValue(HasHeaderProperty);

        /// <summary>
        /// Header is the data used to for the header of each item in the control.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        [Localizability(LocalizationCategory.Label)]
        public string Header
        {
            get => (string)this.GetValue(HeaderProperty);
            set => this.SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display the <seealso cref="Header"/>.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplate HeaderTemplate
        {
            get => (DataTemplate)this.GetValue(HeaderTemplateProperty);
            set => this.SetValue(HeaderTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplateSelector"/> used to display the <seealso cref="Header"/>.
        /// </summary>
        /// <remarks>
        ///     This property is ignored if <seealso cref="HeaderTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector HeaderTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(HeaderTemplateSelectorProperty);
            set => this.SetValue(HeaderTemplateSelectorProperty, value);
        }

        /// <summary>
        ///     HeaderStringFormat is the format used to display the header content as a string.
        ///     This arises only when no template is available.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public string HeaderStringFormat
        {
            get => (string)this.GetValue(HeaderStringFormatProperty);
            set => this.SetValue(HeaderStringFormatProperty, value);
        }

        /// <summary>
        /// This method is invoked when <see cref="Header"/> changes.
        /// </summary>
        /// <param name="oldHeader">The old value of <see cref="Header"/>.</param>
        /// <param name="newHeader">The new value of <see cref="Header"/>.</param>
        protected virtual void OnHeaderChanged(object oldHeader, object newHeader)
        {
            this.UpdateLogicalChild(oldHeader as DependencyObject, newHeader as DependencyObject);
        }

        /// <summary>
        /// This method is invoked when <see cref="HeaderTemplate"/> changes.
        /// </summary>
        /// <param name="oldTemplate">The old value of <see cref="HeaderTemplate"/>.</param>
        /// <param name="newTemplate">The new value of <see cref="HeaderTemplate"/>.</param>
        protected virtual void OnHeaderTemplateChanged(DataTemplate oldTemplate, DataTemplate newTemplate)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="HeaderTemplateSelector"/> property changes.
        /// </summary>
        /// <param name="oldSelector">The old value of <see cref="HeaderTemplateSelector"/>.</param>
        /// <param name="newSelector">The new value of <see cref="HeaderTemplateSelector"/>.</param>
        protected virtual void OnHeaderTemplateSelectorChanged(DataTemplateSelector oldSelector, DataTemplateSelector newSelector)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="HeaderStringFormat"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="HeaderStringFormat"/>.</param>
        /// <param name="newValue">The new value of <see cref="HeaderStringFormat"/>.</param>
        protected virtual void OnHeaderStringFormatChanged(string oldValue, string newValue)
        {
        }

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (Row)d;
            row.SetValue(HasHeaderPropertyKey, (e.NewValue != null) ? BooleanBoxes.True : BooleanBoxes.False);
            row.OnHeaderChanged(e.OldValue, e.NewValue);
        }
    }
}
