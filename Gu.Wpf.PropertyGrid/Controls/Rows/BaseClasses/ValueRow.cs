namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Threading;

    public class ValueRow : Row
    {
#pragma warning disable SA1201 // Elements must appear in the correct order
        /// <summary>Identifies the <see cref="Value"/> dependency property.</summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(object),
            typeof(ValueRow),
            new FrameworkPropertyMetadata(
                defaultValue: null,
                flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                propertyChangedCallback: (d, e) => ((ValueRow)d).OnValueChanged(e.OldValue, e.NewValue),
                coerceValueCallback: null,
                isAnimationProhibited: true,
                defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged));

        /// <summary>Identifies the <see cref="ValueTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty ValueTemplateProperty = DependencyProperty.Register(
            nameof(ValueTemplate),
            typeof(DataTemplate),
            typeof(ValueRow),
            new PropertyMetadata(default(DataTemplate), (d, e) => ((ValueRow)d).OnValueTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue)));

        /// <summary>Identifies the <see cref="ValueTemplateSelector"/> dependency property.</summary>
        public static readonly DependencyProperty ValueTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ValueTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(ValueRow),
            new PropertyMetadata(
                default(DataTemplateSelector),
                (d, e) => ((ValueRow)d).OnValueTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue)));

        /// <summary>Identifies the <see cref="OldValue"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            nameof(OldValue),
            typeof(object),
            typeof(ValueRow),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnOldValueChanged)));

        private static readonly DependencyPropertyKey HasOldValuePropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(HasOldValue),
            typeof(bool),
            typeof(ValueRow),
            new PropertyMetadata(BooleanBoxes.False));

        /// <summary>Identifies the <see cref="HasOldValue"/> dependency property.</summary>
        public static readonly DependencyProperty HasOldValueProperty = HasOldValuePropertyKey.DependencyProperty;

        /// <summary>Identifies the <see cref="OldValueTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueTemplateProperty = DependencyProperty.Register(
            nameof(OldValueTemplate),
            typeof(DataTemplate),
            typeof(ValueRow),
            new PropertyMetadata(default(DataTemplate), (d, e) => ((ValueRow)d).OnOldValueTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue)));

        /// <summary>Identifies the <see cref="OldValueTemplateSelector"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueTemplateSelectorProperty = DependencyProperty.Register(
            nameof(OldValueTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(ValueRow),
            new PropertyMetadata(
                default(DataTemplateSelector),
                (d, e) => ((ValueRow)d).OnOldValueTemplateSelectorChanged((DataTemplateSelector)e.OldValue, (DataTemplateSelector)e.NewValue)));

        /// <summary>Identifies the <see cref="OldValueStringFormat"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueStringFormatProperty = DependencyProperty.Register(
            nameof(OldValueStringFormat),
            typeof(string),
            typeof(ValueRow),
            new PropertyMetadata(
                default(string),
                (d, e) => ((ValueRow)d).OnOldValueStringFormatChanged((string)e.OldValue, (string)e.NewValue)));

        private static readonly DependencyPropertyKey IsDirtyPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(IsDirty),
            typeof(bool?),
            typeof(ValueRow),
            new PropertyMetadata(null));

        /// <summary>Identifies the <see cref="IsDirty"/> dependency property.</summary>
        public static readonly DependencyProperty IsDirtyProperty = IsDirtyPropertyKey.DependencyProperty;

        /// <summary>Identifies the OldDataContext dependency property.</summary>
        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(ValueRow),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits,
                (d, e) => ((ValueRow)d).OnOldDataContextChanged(e.OldValue, e.NewValue)));
#pragma warning restore SA1201 // Elements must appear in the correct order

        static ValueRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ValueRow), new FrameworkPropertyMetadata(typeof(ValueRow)));
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        public object Value
        {
            get => this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display the <seealso cref="Value"/>.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplate ValueTemplate
        {
            get => (DataTemplate)this.GetValue(ValueTemplateProperty);
            set => this.SetValue(ValueTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplateSelector"/> used to display the <seealso cref="Value"/>.
        /// </summary>
        /// <remarks>
        /// This property is ignored if <seealso cref="ValueTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector ValueTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ValueTemplateSelectorProperty);
            set => this.SetValue(ValueTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="OldValue"/> is non-null, false otherwise.
        /// </summary>
        [Bindable(false)]
        [Browsable(false)]
        public bool HasOldValue => (bool)this.GetValue(HasOldValueProperty);

        /// <summary>
        /// Gets or sets the data used to for the old value of each item in the control.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        [Localizability(LocalizationCategory.Label)]
        public object OldValue
        {
            get => (string)this.GetValue(OldValueProperty);
            set => this.SetValue(OldValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display the <seealso cref="OldValue"/>.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplate OldValueTemplate
        {
            get => (DataTemplate)this.GetValue(OldValueTemplateProperty);
            set => this.SetValue(OldValueTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplateSelector"/> used to display the <seealso cref="OldValue"/>.
        /// </summary>
        /// <remarks>
        /// This property is ignored if <seealso cref="OldValueTemplate"/> is set.
        /// </remarks>
        [Bindable(true)]
        [Category("Content")]
        public DataTemplateSelector OldValueTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(OldValueTemplateSelectorProperty);
            set => this.SetValue(OldValueTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the format used to display the old value content as a string.
        /// This arises only when no template is available.
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public string OldValueStringFormat
        {
            get => (string)this.GetValue(OldValueStringFormatProperty);
            set => this.SetValue(OldValueStringFormatProperty, value);
        }

        /// <summary>
        /// Gets or sets the data context with old values.
        /// </summary>
        public object OldDataContext
        {
            get => (object)this.GetValue(OldDataContextProperty);
            set => this.SetValue(OldDataContextProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating if the row has unsaved changes.
        /// </summary>
        public bool? IsDirty
        {
            get => (bool?)this.GetValue(IsDirtyProperty);
            protected set => this.SetValue(IsDirtyPropertyKey, value);
        }

        protected virtual void UpdateIsDirty()
        {
            if (this.ReadLocalValue(OldValueProperty) == DependencyProperty.UnsetValue)
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        /// <summary>
        /// Called when the Value property changes value.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnValueChanged(object oldValue, object newValue)
        {
            this.UpdateIsDirty();
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <summary>
        /// This method is invoked when <see cref="ValueTemplate"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="ValueTemplate"/>.</param>
        /// <param name="newValue">The new value of <see cref="ValueTemplate"/>.</param>
        protected virtual void OnValueTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="ValueTemplateSelector"/> property changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="ValueTemplateSelector"/>.</param>
        /// <param name="newValue">The new value of <see cref="ValueTemplateSelector"/>.</param>
        protected virtual void OnValueTemplateSelectorChanged(DataTemplateSelector oldValue, DataTemplateSelector newValue)
        {
        }

        /// <summary>
        /// This method is invoked when <see cref="OldValue"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldValue"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldValue"/>.</param>
        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
            this.UpdateIsDirty();
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <summary>
        /// This method is invoked when <see cref="OldValueTemplate"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldValueTemplate"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldValueTemplate"/>.</param>
        protected virtual void OnOldValueTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="OldValueTemplateSelector"/> property changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldValueTemplateSelector"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldValueTemplateSelector"/>.</param>
        protected virtual void OnOldValueTemplateSelectorChanged(DataTemplateSelector oldValue, DataTemplateSelector newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="OldValueStringFormat"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldValueStringFormat"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldValueStringFormat"/>.</param>
        protected virtual void OnOldValueStringFormatChanged(string oldValue, string newValue)
        {
        }

        /// <summary>
        /// This method is invoked when the <see cref="OldDataContext"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldDataContext"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldDataContext"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnOldDataContextChanged(object oldValue, object newValue)
        {
            var oldValueBinding = BindingOperations.GetBinding(this, OldValueProperty);
            if (oldValueBinding != null)
            {
                // We don't replace any bindings.
                return;
            }

            if (this.IsLoaded)
            {
                var valueBinding = BindingOperations.GetBinding(this, ValueProperty);
                if (valueBinding != null)
                {
                    var path = $"{OldDataContextProperty.Name}.{valueBinding.Path.Path}";
                    oldValueBinding = new Binding(path)
                    {
                        Mode = BindingMode.OneWay,
                        Source = this,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };

                    _ = BindingOperations.SetBinding(this, OldValueProperty, oldValueBinding);
                }
            }
            else
            {
                _ = this.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => this.OnOldDataContextChanged(oldValue, newValue)));
            }
        }

        private static void OnOldValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ValueRow)d;
            row.SetValue(HasOldValuePropertyKey, (e.NewValue != null) ? BooleanBoxes.True : BooleanBoxes.False);
            row.OnOldValueChanged(e.OldValue, e.NewValue);
        }
    }
}
