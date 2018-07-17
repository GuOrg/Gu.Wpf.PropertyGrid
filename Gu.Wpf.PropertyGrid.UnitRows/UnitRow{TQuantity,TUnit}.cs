namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public abstract class UnitRow<TQuantity, TUnit> : UnitRow, IQuantityFormatter
        where TQuantity : struct, IQuantity<TUnit>
        where TUnit : IUnit<TQuantity>
    {
        /// <summary>Identifies the <see cref="Value"/> dependency property.</summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(TQuantity?),
            typeof(UnitRow<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(
                defaultValue: default(TQuantity?),
                flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                propertyChangedCallback: (d, e) => ((UnitRow<TQuantity, TUnit>)d).OnValueChanged(e.OldValue, e.NewValue),
                coerceValueCallback: null,
                isAnimationProhibited: true,
                defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged));

        /// <summary>Identifies the <see cref="MinValue"/> dependency property.</summary>
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(TQuantity?),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(null, (d, e) => ((UnitRow<TQuantity, TUnit>)d).OnMinValueChanged((TQuantity?)e.OldValue, (TQuantity?)e.NewValue)));

        /// <summary>Identifies the <see cref="MaxValue"/> dependency property.</summary>
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(TQuantity?),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(null, (d, e) => ((UnitRow<TQuantity, TUnit>)d).OnMaxValueChanged((TQuantity?)e.OldValue, (TQuantity?)e.NewValue)));

        public static readonly TUnit DefaultUnit = (TUnit)default(TUnit).SiUnit;

        /// <summary>Identifies the <see cref="Unit"/> dependency property.</summary>
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            nameof(Unit),
            typeof(TUnit),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(DefaultUnit, (d, e) => ((UnitRow<TQuantity, TUnit>)d).OnUnitChanged((TUnit)e.OldValue, (TUnit)e.NewValue)));

        /// <summary>The SI-unit for the TUnit.</summary>
        private bool isUpdatingScalarValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitRow{TQuantity, TUnit}"/> class.
        /// </summary>
        protected UnitRow()
            : base(ValueProperty)
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TQuantity? Value
        {
            get => (TQuantity?)this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// The value is inclusive.
        /// If set to null no check for min is done.
        /// </summary>
        public TQuantity? MinValue
        {
            get => (TQuantity?)this.GetValue(MinValueProperty);
            set => this.SetValue(MinValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// The value is inclusive.
        /// If set to null no check for max is done.
        /// </summary>
        public TQuantity? MaxValue
        {
            get => (TQuantity?)this.GetValue(MaxValueProperty);
            set => this.SetValue(MaxValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the unit of the <see cref="Value"/>
        /// </summary>
        public TUnit Unit
        {
            get => (TUnit)this.GetValue(UnitProperty);
            set => this.SetValue(UnitProperty, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var valueBinding = BindingOperations.GetBindingExpression(this, ValueProperty);
            this.OnApplyTemplateBase(valueBinding, this.OnTemplateChildError);
        }

        /// <inheritdoc/>
        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is TQuantity))
            {
                return "wrong type";
            }

            var qty = (TQuantity)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        /// <summary>
        /// Error eventhandler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">arguments</param>
        protected void OnTemplateChildError(object sender, ValidationErrorEventArgs args)
        {
            this.OnTemplateChildErrorBase((DependencyObject)args.Source, ValueProperty);
        }

        /// <summary>
        /// Called when the <see cref="ValueProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (TQuantity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        /// <summary>
        /// Called when the <see cref="MinValueProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnMinValueChanged(TQuantity? oldValue, TQuantity? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        /// <summary>
        /// Called when the <see cref="MaxValueProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnMaxValueChanged(TQuantity? oldValue, TQuantity? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        /// <summary>
        /// Called when the <see cref="UnitRow.ScalarValueProperty"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        /// <summary>
        /// Called when the <see cref="UnitRow.ScalarMinValueProperty"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        /// <summary>
        /// Called when the <see cref="UnitRow.ScalarMaxValueProperty"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        /// <summary>
        /// This method is invoked when the <see cref="Unit"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value of <see cref="Unit"/>.</param>
        /// <param name="newValue">The new value of <see cref="Unit"/>.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnUnitChanged(TUnit oldValue, TUnit newValue)
        {
            this.UnitText = this.CreateUnitText(this.SymbolFormat);
            this.SetScalarValue(ScalarValueProperty, this.Value);
            this.SetScalarValue(ScalarMinValueProperty, this.MinValue);
            this.SetScalarValue(ScalarMaxValueProperty, this.MaxValue);
        }

        /// <inheritdoc />
        protected override void UpdateIsDirty()
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
        /// Set <paramref name="property"/> to a value in <see cref="Unit"/>
        /// </summary>
        /// <param name="property">The property on this instance.</param>
        /// <param name="quantity">The value to convert to current unit</param>
        protected void SetScalarValue(DependencyProperty property, TQuantity? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        /// <summary>
        /// Set <paramref name="property"/> to a value in <see cref="Unit"/>
        /// </summary>
        /// <param name="property">The property on this instance.</param>
        /// <param name="value">The value to convert to current unit</param>
        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (TQuantity?)null;
            this.SetCurrentValue(property, qty);
        }

        /// <summary>
        /// Create the suffix from the current <see cref="Unit"/>
        /// </summary>
        /// <param name="format">The <see cref="SymbolFormat"/></param>
        /// <returns>The string representation of the unit.</returns>
        protected override string CreateUnitText(SymbolFormat format)
        {
            return default(TQuantity).ToString(this.Unit, format).Trim('0');
        }

        /// <inheritdoc />
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.UnitText = this.CreateUnitText(this.SymbolFormat);
        }
    }
}
