namespace Gu.Wpf.PropertyGrid
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Data;

    public abstract partial class Row
    {
#pragma warning disable SA1202 // Elements must be ordered by access
        /// <summary>Identifies the IsReadOnly dependency property.</summary>
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the <see cref="OldValue"/> dependency property.</summary>
        public static readonly DependencyProperty OldValueProperty = DependencyProperty.Register(
            nameof(OldValue),
            typeof(object),
            typeof(Row),
            new PropertyMetadata(null, (d, e) => ((Row)d).OnOldValueChanged(e.OldValue, e.NewValue)));

        private static readonly DependencyPropertyKey IsDirtyPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(IsDirty),
            typeof(bool?),
            typeof(Row),
            new PropertyMetadata(null));

        /// <summary>Identifies the <see cref="IsDirty"/> dependency property.</summary>
        public static readonly DependencyProperty IsDirtyProperty = IsDirtyPropertyKey.DependencyProperty;
#pragma warning restore SA1202 // Elements must be ordered by access

        /// <summary>
        /// Gets or sets a value indicating whether the row is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)this.GetValue(IsReadOnlyProperty); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the old value, can be null.
        /// This is used when calculating <see cref="IsDirty"/> and for display in the form.
        /// </summary>
        public object OldValue
        {
            get => this.GetValue(OldValueProperty);
            set => this.SetValue(OldValueProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating if the row has unsaved changes.
        /// </summary>
        public bool? IsDirty
        {
            get => (bool?)this.GetValue(IsDirtyProperty);
            protected set => this.SetValue(IsDirtyPropertyKey, value);
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
        /// This method is invoked when the <see cref="OldDataContext"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldDataContext"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldDataContext"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnOldDataContextChanged(object oldValue, object newValue)
        {
            if (this.ValueDependencyProperty == null)
            {
                return;
            }

            var oldValueBinding = BindingOperations.GetBinding(this, OldValueProperty);
            if (oldValueBinding != null)
            {
                // We don't replace any bindings.
                return;
            }

            var valueBinding = BindingOperations.GetBinding(this, this.ValueDependencyProperty);
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

        /// <summary>
        /// This method is invoked when the <see cref="OldValue"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="OldValue"/>.</param>
        /// <param name="newValue">The new value of <see cref="OldValue"/>.</param>
        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
            this.UpdateIsDirty();
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }
    }
}
