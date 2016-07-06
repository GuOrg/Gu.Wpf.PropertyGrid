namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System;
    using System.Windows;
    using Gu.Units;
    using Gu.Wpf.NumericInput;
    using Gu.Wpf.PropertyGrid.NumericRows;

    public abstract class UnitRowGeneric<TQuantity, TUnit> : NumericRow<TQuantity>, IQuantityFormatter
        where TQuantity : struct, IComparable<TQuantity>, IQuantity<TUnit>
        where TUnit : IUnit<TQuantity>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ScalarValueProperty = DependencyProperty.Register(
            "ScalarValue",
            typeof(double?),
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarValueChanged));

        public static readonly DependencyProperty ScalarMinValueProperty = DependencyProperty.Register(
            "ScalarMinValue",
            typeof(double?),
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarMinValueChanged));

        public static readonly DependencyProperty ScalarMaxValueProperty = DependencyProperty.Register(
            "ScalarMaxValue",
            typeof(double?),
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TUnit),
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new PropertyMetadata(default(TUnit), OnUnitChanged));

        public static readonly DependencyProperty SymbolFormatProperty = UnitRow.SymbolFormatProperty.AddOwner(
            typeof(UnitRowGeneric<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(
                UnitRow.DefaultSymbolFormat,
                FrameworkPropertyMetadataOptions.Inherits,
                OnSymbolFormatChanged));

        private bool isUpdatingScalarValue;

        public int? DecimalDigits
        {
            get { return (int?)this.GetValue(DecimalDigitsProperty); }
            set { this.SetValue(DecimalDigitsProperty, value); }
        }

        public bool CanValueBeNull
        {
            get { return (bool)this.GetValue(CanValueBeNullProperty); }
            set { this.SetValue(CanValueBeNullProperty, value); }
        }

        public double? ScalarValue
        {
            get { return (double?)this.GetValue(ScalarValueProperty); }
            set { this.SetValue(ScalarValueProperty, value); }
        }

        public double? ScalarMinValue
        {
            get { return (double?)this.GetValue(ScalarMinValueProperty); }
            set { this.SetValue(ScalarMinValueProperty, value); }
        }

        public double? ScalarMaxValue
        {
            get { return (double?)this.GetValue(ScalarMaxValueProperty); }
            set { this.SetValue(ScalarMaxValueProperty, value); }
        }

        public TUnit Unit
        {
            get { return (TUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        public SymbolFormat SymbolFormat
        {
            get { return (SymbolFormat)this.GetValue(SymbolFormatProperty); }
            set { this.SetValue(SymbolFormatProperty, value); }
        }

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

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitRowGeneric<TQuantity, TUnit>)d;
            var oldSuffix = CreateSuffix((TUnit)e.OldValue, control.SymbolFormat);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = CreateSuffix((TUnit)e.NewValue, control.SymbolFormat);
            }

            SetScalarValue(d, ScalarValueProperty, (TQuantity?)d.GetValue(ValueProperty));
            SetScalarValue(d, ScalarMinValueProperty, (TQuantity?)d.GetValue(MinValueProperty));
            SetScalarValue(d, ScalarMaxValueProperty, (TQuantity?)d.GetValue(MaxValueProperty));
        }

        protected static string CreateSuffix(TUnit unit, SymbolFormat symbolFormat)
        {
            return unit.ToString(symbolFormat);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            SetScalarValue(this, ScalarValueProperty, (TQuantity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected override void OnMinValueChanged(TQuantity? oldValue, TQuantity? newValue)
        {
            SetScalarValue(this, ScalarMinValueProperty, newValue);
            base.OnMinValueChanged(oldValue, newValue);
        }

        protected override void OnMaxValueChanged(TQuantity? oldValue, TQuantity? newValue)
        {
            SetScalarValue(this, ScalarMaxValueProperty, newValue);
            base.OnMaxValueChanged(oldValue, newValue);
        }

        private static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitRowGeneric<TQuantity, TUnit>)d;
            var oldSuffix = CreateSuffix(control.Unit, (SymbolFormat)e.OldValue);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = CreateSuffix(control.Unit, (SymbolFormat)e.NewValue);
            }
        }

        private static void OnScalarValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetQuantityValue(d, ValueProperty, (double?)e.NewValue);
        }

        private static void OnScalarMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetQuantityValue(d, MinValueProperty, (double?)e.NewValue);
        }

        private static void OnScalarMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetQuantityValue(d, MaxValueProperty, (double?)e.NewValue);
        }

        private static void SetQuantityValue(DependencyObject o, DependencyProperty property, double? value)
        {
            var control = (UnitRowGeneric<TQuantity, TUnit>)o;
            if (control.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? control.Unit.CreateQuantity(value.Value)
                : (TQuantity?)null;
            control.SetCurrentValue(property, qty);
        }

        private static void SetScalarValue(DependencyObject o, DependencyProperty property, TQuantity? quantity)
        {
            var control = (UnitRowGeneric<TQuantity, TUnit>)o;
            control.isUpdatingScalarValue = true;
            var value = quantity != null
                ? control.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            control.SetCurrentValue(property, value);
            control.isUpdatingScalarValue = false;
        }
    }
}