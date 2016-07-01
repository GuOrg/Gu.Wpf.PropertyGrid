namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;

    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public abstract class UnitRow<TQuantity, TUnit> : NumericRow<TQuantity>
        where TQuantity : struct, IComparable<TQuantity>, IQuantity<TUnit>
        where TUnit : IUnit<TQuantity>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(UnitRow<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(UnitRow<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ScalarValueProperty = DependencyProperty.Register(
            "ScalarValue",
            typeof(double?),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarValueChanged));

        public static readonly DependencyProperty ScalarMinValueProperty = DependencyProperty.Register(
            "ScalarMinValue",
            typeof(double?),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarMinValueChanged));

        public static readonly DependencyProperty ScalarMaxValueProperty = DependencyProperty.Register(
            "ScalarMaxValue",
            typeof(double?),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(default(double?), OnScalarMaxValueChanged));

        private static readonly DependencyPropertyKey OldStringValuePropertyKey = DependencyProperty.RegisterReadOnly(
            "OldStringValue",
            typeof(string),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty OldStringValueProperty = OldStringValuePropertyKey.DependencyProperty;

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TUnit),
            typeof(UnitRow<TQuantity, TUnit>),
            new PropertyMetadata(default(TUnit), OnUnitChanged));

        public static readonly DependencyProperty SymbolFormatProperty = UnitRow.SymbolFormatProperty.AddOwner(
            typeof(UnitRow<TQuantity, TUnit>),
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

        public string OldStringValue
        {
            get { return (string)this.GetValue(OldStringValueProperty); }
            protected set { this.SetValue(OldStringValuePropertyKey, value); }
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

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitRow<TQuantity, TUnit>)d;
            var oldSuffix = CreateSuffix((TUnit)e.OldValue, control.SymbolFormat);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = CreateSuffix((TUnit)e.NewValue, control.SymbolFormat);
            }

            SetScalarValue(d, ScalarValueProperty, (TQuantity?)d.GetValue(ValueProperty));
            SetScalarValue(d, ScalarMinValueProperty, (TQuantity?)d.GetValue(MinValueProperty));
            SetScalarValue(d, ScalarMaxValueProperty, (TQuantity?)d.GetValue(MaxValueProperty));
            control.UpdateOldText();
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

        protected override void OnOldValueChanged(object oldValue, object newValue)
        {
            base.OnOldValueChanged(oldValue, newValue);
            this.UpdateOldText();
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
            var control = (UnitRow<TQuantity, TUnit>)d;
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
            var control = (UnitRow<TQuantity, TUnit>)o;
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
            var control = (UnitRow<TQuantity, TUnit>)o;
            control.isUpdatingScalarValue = true;
            var value = quantity != null
                ? control.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            control.SetCurrentValue(property, value);
            control.isUpdatingScalarValue = false;
        }

        private void UpdateOldText()
        {
            var text = (this.OldValue as TQuantity?)?.ToString(this.Unit, this.SymbolFormat) ?? string.Empty;
            this.OldStringValue = text;
        }
    }
}