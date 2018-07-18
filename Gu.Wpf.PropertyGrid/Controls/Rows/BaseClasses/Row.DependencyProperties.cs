namespace Gu.Wpf.PropertyGrid
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    public abstract partial class Row
    {
#pragma warning disable SA1202 // Elements must be ordered by access
        /// <summary>Identifies the IsReadOnly dependency property.</summary>
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

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

                /// <summary>Identifies the <see cref="Suffix"/> dependency property.</summary>
        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
            nameof(Suffix),
            typeof(object),
            typeof(Row),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSuffixChanged)));

        private static readonly DependencyPropertyKey HasSuffixPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(HasSuffix),
            typeof(bool),
            typeof(Row),
            new PropertyMetadata(BooleanBoxes.False));

        /// <summary>Identifies the <see cref="HasSuffix"/> dependency property.</summary>
        public static readonly DependencyProperty HasSuffixProperty = HasSuffixPropertyKey.DependencyProperty;

        /// <summary>Identifies the <see cref="SuffixTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty SuffixTemplateProperty = DependencyProperty.Register(
            nameof(SuffixTemplate),
            typeof(DataTemplate),
            typeof(Row),
            new PropertyMetadata(default(DataTemplate), (d, e) => ((Row)d).OnSuffixTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue)));

        /// <summary>Identifies the <see cref="SuffixTemplateSelector"/> dependency property.</summary>
        public static readonly DependencyProperty SuffixTemplateSelectorProperty = DependencyProperty.Register(
            nameof(SuffixTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(Row),
            new PropertyMetadata(default(DataTemplateSelector), (d, e) => ((Row)d).OnSuffixTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue)));

        /// <summary>Identifies the <see cref="SuffixStringFormat"/> dependency property.</summary>
        public static readonly DependencyProperty SuffixStringFormatProperty = DependencyProperty.Register(
            nameof(SuffixStringFormat),
            typeof(string),
            typeof(Row),
            new PropertyMetadata(default(string), (d, e) => ((Row)d).OnSuffixStringFormatChanged((string)e.OldValue, (string)e.NewValue)));
#pragma warning restore SA1202 // Elements must be ordered by access

        /// <summary>
        /// Gets or sets a value indicating whether the row is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get => (bool)this.GetValue(IsReadOnlyProperty);
            set => this.SetValue(IsReadOnlyProperty, value);
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="Header"/> is non-null, false otherwise.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        public bool HasHeader => (bool)this.GetValue(HasHeaderProperty);

        /// <summary>
        /// Gets or sets the data used to for the header of each item in the control.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        [Localizability(LocalizationCategory.Label)]
        public object Header
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
        /// This property is ignored if <seealso cref="HeaderTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector HeaderTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(HeaderTemplateSelectorProperty);
            set => this.SetValue(HeaderTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the format used to display the header content as a string.
        /// This arises only when no template is available.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public string HeaderStringFormat
        {
            get => (string)this.GetValue(HeaderStringFormatProperty);
            set => this.SetValue(HeaderStringFormatProperty, value);
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="Suffix"/> is non-null, false otherwise.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        public bool HasSuffix => (bool)this.GetValue(HasSuffixProperty);

        /// <summary>
        /// Gets or sets the data used to for the Suffix of each item in the control.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        [Localizability(LocalizationCategory.Label)]
        public object Suffix
        {
            get => (string)this.GetValue(SuffixProperty);
            set => this.SetValue(SuffixProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display the <seealso cref="Suffix"/>.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplate SuffixTemplate
        {
            get => (DataTemplate)this.GetValue(SuffixTemplateProperty);
            set => this.SetValue(SuffixTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplateSelector"/> used to display the <seealso cref="Suffix"/>.
        /// </summary>
        /// <remarks>
        /// This property is ignored if <seealso cref="SuffixTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector SuffixTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(SuffixTemplateSelectorProperty);
            set => this.SetValue(SuffixTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the format used to display the Suffix content as a string.
        /// This arises only when no template is available.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public string SuffixStringFormat
        {
            get => (string)this.GetValue(SuffixStringFormatProperty);
            set => this.SetValue(SuffixStringFormatProperty, value);
        }

                /// <summary>
        /// This method is invoked when <see cref="Header"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="Header"/>.</param>
        /// <param name="newValue">The new value of <see cref="Header"/>.</param>
        protected virtual void OnHeaderChanged(object oldValue, object newValue)
        {
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <summary>
        /// This method is invoked when <see cref="HeaderTemplate"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="HeaderTemplate"/>.</param>
        /// <param name="newValue">The new value of <see cref="HeaderTemplate"/>.</param>
        protected virtual void OnHeaderTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="HeaderTemplateSelector"/> property changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="HeaderTemplateSelector"/>.</param>
        /// <param name="newValue">The new value of <see cref="HeaderTemplateSelector"/>.</param>
        protected virtual void OnHeaderTemplateSelectorChanged(DataTemplateSelector oldValue, DataTemplateSelector newValue)
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

        /// <summary>
        /// This method is invoked when <see cref="Suffix"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="Suffix"/>.</param>
        /// <param name="newValue">The new value of <see cref="Suffix"/>.</param>
        protected virtual void OnSuffixChanged(object oldValue, object newValue)
        {
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <summary>
        /// This method is invoked when <see cref="SuffixTemplate"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="SuffixTemplate"/>.</param>
        /// <param name="newValue">The new value of <see cref="SuffixTemplate"/>.</param>
        protected virtual void OnSuffixTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="SuffixTemplateSelector"/> property changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="SuffixTemplateSelector"/>.</param>
        /// <param name="newValue">The new value of <see cref="SuffixTemplateSelector"/>.</param>
        protected virtual void OnSuffixTemplateSelectorChanged(DataTemplateSelector oldValue, DataTemplateSelector newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="SuffixStringFormat"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="SuffixStringFormat"/>.</param>
        /// <param name="newValue">The new value of <see cref="SuffixStringFormat"/>.</param>
        protected virtual void OnSuffixStringFormatChanged(string oldValue, string newValue)
        {
        }

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (Row)d;
            row.SetValue(HasHeaderPropertyKey, (e.NewValue != null) ? BooleanBoxes.True : BooleanBoxes.False);
            row.OnHeaderChanged(e.OldValue, e.NewValue);
        }

        private static void OnSuffixChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (Row)d;
            row.SetValue(HasSuffixPropertyKey, (e.NewValue != null) ? BooleanBoxes.True : BooleanBoxes.False);
            row.OnSuffixChanged(e.OldValue, e.NewValue);
        }
    }
}
