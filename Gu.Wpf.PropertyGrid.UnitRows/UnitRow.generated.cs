#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1118 // Parameter must not span multiple lines
namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using System.Windows.Data;
    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public class AccelerationRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Acceleration?),
        typeof(AccelerationRow),
        new FrameworkPropertyMetadata(
            default(Acceleration?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Acceleration?),
            typeof(AccelerationRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Acceleration?),
            typeof(AccelerationRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AccelerationUnit),
            typeof(AccelerationRow),
            new PropertyMetadata(default(AccelerationUnit).SiUnit, OnUnitChanged));

        public static readonly AccelerationUnit DefaultUnit = default(AccelerationUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccelerationRow), new FrameworkPropertyMetadata(typeof(AccelerationRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AccelerationRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Acceleration? Value
        {
            get { return (Acceleration?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Acceleration? MinValue
        {
            get { return (Acceleration?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Acceleration? MaxValue
        {
            get { return (Acceleration?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AccelerationUnit Unit
        {
            get { return (AccelerationUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Acceleration))
            {
                return "wrong type";
            }

            var qty = (Acceleration)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AccelerationUnit unit)
        {
            return default(Acceleration).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AccelerationRow)d).OnMinValueChanged((Acceleration?)e.OldValue, (Acceleration?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AccelerationRow)d).OnMaxValueChanged((Acceleration?)e.OldValue, (Acceleration?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AccelerationRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AccelerationUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AccelerationUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Acceleration?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Acceleration? oldValue, Acceleration? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Acceleration? oldValue, Acceleration? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Acceleration? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Acceleration?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AmountOfSubstanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AmountOfSubstance?),
        typeof(AmountOfSubstanceRow),
        new FrameworkPropertyMetadata(
            default(AmountOfSubstance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AmountOfSubstance?),
            typeof(AmountOfSubstanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AmountOfSubstance?),
            typeof(AmountOfSubstanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AmountOfSubstanceUnit),
            typeof(AmountOfSubstanceRow),
            new PropertyMetadata(default(AmountOfSubstanceUnit).SiUnit, OnUnitChanged));

        public static readonly AmountOfSubstanceUnit DefaultUnit = default(AmountOfSubstanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AmountOfSubstanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountOfSubstanceRow), new FrameworkPropertyMetadata(typeof(AmountOfSubstanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AmountOfSubstanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AmountOfSubstance? Value
        {
            get { return (AmountOfSubstance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AmountOfSubstance? MinValue
        {
            get { return (AmountOfSubstance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AmountOfSubstance? MaxValue
        {
            get { return (AmountOfSubstance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AmountOfSubstanceUnit Unit
        {
            get { return (AmountOfSubstanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AmountOfSubstance))
            {
                return "wrong type";
            }

            var qty = (AmountOfSubstance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AmountOfSubstanceUnit unit)
        {
            return default(AmountOfSubstance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AmountOfSubstanceRow)d).OnMinValueChanged((AmountOfSubstance?)e.OldValue, (AmountOfSubstance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AmountOfSubstanceRow)d).OnMaxValueChanged((AmountOfSubstance?)e.OldValue, (AmountOfSubstance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AmountOfSubstanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AmountOfSubstanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AmountOfSubstanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AmountOfSubstance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AmountOfSubstance? oldValue, AmountOfSubstance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AmountOfSubstance? oldValue, AmountOfSubstance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AmountOfSubstance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AmountOfSubstance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AngleRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Angle?),
        typeof(AngleRow),
        new FrameworkPropertyMetadata(
            default(Angle?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Angle?),
            typeof(AngleRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Angle?),
            typeof(AngleRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AngleUnit),
            typeof(AngleRow),
            new PropertyMetadata(default(AngleUnit).SiUnit, OnUnitChanged));

        public static readonly AngleUnit DefaultUnit = default(AngleUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngleRow), new FrameworkPropertyMetadata(typeof(AngleRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AngleRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Angle? Value
        {
            get { return (Angle?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Angle? MinValue
        {
            get { return (Angle?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Angle? MaxValue
        {
            get { return (Angle?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AngleUnit Unit
        {
            get { return (AngleUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Angle))
            {
                return "wrong type";
            }

            var qty = (Angle)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AngleUnit unit)
        {
            return default(Angle).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngleRow)d).OnMinValueChanged((Angle?)e.OldValue, (Angle?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngleRow)d).OnMaxValueChanged((Angle?)e.OldValue, (Angle?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AngleRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AngleUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AngleUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Angle?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Angle? oldValue, Angle? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Angle? oldValue, Angle? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Angle? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Angle?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AnglePerUnitlessRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AnglePerUnitless?),
        typeof(AnglePerUnitlessRow),
        new FrameworkPropertyMetadata(
            default(AnglePerUnitless?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AnglePerUnitless?),
            typeof(AnglePerUnitlessRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AnglePerUnitless?),
            typeof(AnglePerUnitlessRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AnglePerUnitlessUnit),
            typeof(AnglePerUnitlessRow),
            new PropertyMetadata(default(AnglePerUnitlessUnit).SiUnit, OnUnitChanged));

        public static readonly AnglePerUnitlessUnit DefaultUnit = default(AnglePerUnitlessUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AnglePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnglePerUnitlessRow), new FrameworkPropertyMetadata(typeof(AnglePerUnitlessRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AnglePerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AnglePerUnitless? Value
        {
            get { return (AnglePerUnitless?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AnglePerUnitless? MinValue
        {
            get { return (AnglePerUnitless?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AnglePerUnitless? MaxValue
        {
            get { return (AnglePerUnitless?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AnglePerUnitlessUnit Unit
        {
            get { return (AnglePerUnitlessUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AnglePerUnitless))
            {
                return "wrong type";
            }

            var qty = (AnglePerUnitless)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AnglePerUnitlessUnit unit)
        {
            return default(AnglePerUnitless).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnglePerUnitlessRow)d).OnMinValueChanged((AnglePerUnitless?)e.OldValue, (AnglePerUnitless?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnglePerUnitlessRow)d).OnMaxValueChanged((AnglePerUnitless?)e.OldValue, (AnglePerUnitless?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AnglePerUnitlessRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AnglePerUnitlessUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AnglePerUnitlessUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AnglePerUnitless?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AnglePerUnitless? oldValue, AnglePerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AnglePerUnitless? oldValue, AnglePerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AnglePerUnitless? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AnglePerUnitless?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AngularAccelerationRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AngularAcceleration?),
        typeof(AngularAccelerationRow),
        new FrameworkPropertyMetadata(
            default(AngularAcceleration?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AngularAcceleration?),
            typeof(AngularAccelerationRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AngularAcceleration?),
            typeof(AngularAccelerationRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AngularAccelerationUnit),
            typeof(AngularAccelerationRow),
            new PropertyMetadata(default(AngularAccelerationUnit).SiUnit, OnUnitChanged));

        public static readonly AngularAccelerationUnit DefaultUnit = default(AngularAccelerationUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AngularAccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularAccelerationRow), new FrameworkPropertyMetadata(typeof(AngularAccelerationRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AngularAccelerationRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AngularAcceleration? Value
        {
            get { return (AngularAcceleration?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AngularAcceleration? MinValue
        {
            get { return (AngularAcceleration?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AngularAcceleration? MaxValue
        {
            get { return (AngularAcceleration?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AngularAccelerationUnit Unit
        {
            get { return (AngularAccelerationUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AngularAcceleration))
            {
                return "wrong type";
            }

            var qty = (AngularAcceleration)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AngularAccelerationUnit unit)
        {
            return default(AngularAcceleration).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularAccelerationRow)d).OnMinValueChanged((AngularAcceleration?)e.OldValue, (AngularAcceleration?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularAccelerationRow)d).OnMaxValueChanged((AngularAcceleration?)e.OldValue, (AngularAcceleration?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AngularAccelerationRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AngularAccelerationUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AngularAccelerationUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AngularAcceleration?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AngularAcceleration? oldValue, AngularAcceleration? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AngularAcceleration? oldValue, AngularAcceleration? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AngularAcceleration? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AngularAcceleration?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AngularJerkRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AngularJerk?),
        typeof(AngularJerkRow),
        new FrameworkPropertyMetadata(
            default(AngularJerk?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AngularJerk?),
            typeof(AngularJerkRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AngularJerk?),
            typeof(AngularJerkRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AngularJerkUnit),
            typeof(AngularJerkRow),
            new PropertyMetadata(default(AngularJerkUnit).SiUnit, OnUnitChanged));

        public static readonly AngularJerkUnit DefaultUnit = default(AngularJerkUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AngularJerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularJerkRow), new FrameworkPropertyMetadata(typeof(AngularJerkRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AngularJerkRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AngularJerk? Value
        {
            get { return (AngularJerk?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AngularJerk? MinValue
        {
            get { return (AngularJerk?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AngularJerk? MaxValue
        {
            get { return (AngularJerk?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AngularJerkUnit Unit
        {
            get { return (AngularJerkUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AngularJerk))
            {
                return "wrong type";
            }

            var qty = (AngularJerk)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AngularJerkUnit unit)
        {
            return default(AngularJerk).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularJerkRow)d).OnMinValueChanged((AngularJerk?)e.OldValue, (AngularJerk?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularJerkRow)d).OnMaxValueChanged((AngularJerk?)e.OldValue, (AngularJerk?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AngularJerkRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AngularJerkUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AngularJerkUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AngularJerk?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AngularJerk? oldValue, AngularJerk? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AngularJerk? oldValue, AngularJerk? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AngularJerk? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AngularJerk?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AngularSpeedRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AngularSpeed?),
        typeof(AngularSpeedRow),
        new FrameworkPropertyMetadata(
            default(AngularSpeed?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AngularSpeed?),
            typeof(AngularSpeedRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AngularSpeed?),
            typeof(AngularSpeedRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AngularSpeedUnit),
            typeof(AngularSpeedRow),
            new PropertyMetadata(default(AngularSpeedUnit).SiUnit, OnUnitChanged));

        public static readonly AngularSpeedUnit DefaultUnit = default(AngularSpeedUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AngularSpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularSpeedRow), new FrameworkPropertyMetadata(typeof(AngularSpeedRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AngularSpeedRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AngularSpeed? Value
        {
            get { return (AngularSpeed?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AngularSpeed? MinValue
        {
            get { return (AngularSpeed?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AngularSpeed? MaxValue
        {
            get { return (AngularSpeed?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AngularSpeedUnit Unit
        {
            get { return (AngularSpeedUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AngularSpeed))
            {
                return "wrong type";
            }

            var qty = (AngularSpeed)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AngularSpeedUnit unit)
        {
            return default(AngularSpeed).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularSpeedRow)d).OnMinValueChanged((AngularSpeed?)e.OldValue, (AngularSpeed?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AngularSpeedRow)d).OnMaxValueChanged((AngularSpeed?)e.OldValue, (AngularSpeed?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AngularSpeedRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AngularSpeedUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AngularSpeedUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AngularSpeed?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AngularSpeed? oldValue, AngularSpeed? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AngularSpeed? oldValue, AngularSpeed? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AngularSpeed? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AngularSpeed?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AreaRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Area?),
        typeof(AreaRow),
        new FrameworkPropertyMetadata(
            default(Area?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Area?),
            typeof(AreaRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Area?),
            typeof(AreaRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AreaUnit),
            typeof(AreaRow),
            new PropertyMetadata(default(AreaUnit).SiUnit, OnUnitChanged));

        public static readonly AreaUnit DefaultUnit = default(AreaUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AreaRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaRow), new FrameworkPropertyMetadata(typeof(AreaRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AreaRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Area? Value
        {
            get { return (Area?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Area? MinValue
        {
            get { return (Area?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Area? MaxValue
        {
            get { return (Area?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AreaUnit Unit
        {
            get { return (AreaUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Area))
            {
                return "wrong type";
            }

            var qty = (Area)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AreaUnit unit)
        {
            return default(Area).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AreaRow)d).OnMinValueChanged((Area?)e.OldValue, (Area?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AreaRow)d).OnMaxValueChanged((Area?)e.OldValue, (Area?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AreaRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AreaUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AreaUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Area?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Area? oldValue, Area? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Area? oldValue, Area? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Area? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Area?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class AreaDensityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(AreaDensity?),
        typeof(AreaDensityRow),
        new FrameworkPropertyMetadata(
            default(AreaDensity?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(AreaDensity?),
            typeof(AreaDensityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(AreaDensity?),
            typeof(AreaDensityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(AreaDensityUnit),
            typeof(AreaDensityRow),
            new PropertyMetadata(default(AreaDensityUnit).SiUnit, OnUnitChanged));

        public static readonly AreaDensityUnit DefaultUnit = default(AreaDensityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static AreaDensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaDensityRow), new FrameworkPropertyMetadata(typeof(AreaDensityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(AreaDensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public AreaDensity? Value
        {
            get { return (AreaDensity?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public AreaDensity? MinValue
        {
            get { return (AreaDensity?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public AreaDensity? MaxValue
        {
            get { return (AreaDensity?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public AreaDensityUnit Unit
        {
            get { return (AreaDensityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is AreaDensity))
            {
                return "wrong type";
            }

            var qty = (AreaDensity)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, AreaDensityUnit unit)
        {
            return default(AreaDensity).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AreaDensityRow)d).OnMinValueChanged((AreaDensity?)e.OldValue, (AreaDensity?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AreaDensityRow)d).OnMaxValueChanged((AreaDensity?)e.OldValue, (AreaDensity?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (AreaDensityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (AreaDensityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (AreaDensityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (AreaDensity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(AreaDensity? oldValue, AreaDensity? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(AreaDensity? oldValue, AreaDensity? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, AreaDensity? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (AreaDensity?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class CapacitanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Capacitance?),
        typeof(CapacitanceRow),
        new FrameworkPropertyMetadata(
            default(Capacitance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Capacitance?),
            typeof(CapacitanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Capacitance?),
            typeof(CapacitanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(CapacitanceUnit),
            typeof(CapacitanceRow),
            new PropertyMetadata(default(CapacitanceUnit).SiUnit, OnUnitChanged));

        public static readonly CapacitanceUnit DefaultUnit = default(CapacitanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static CapacitanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CapacitanceRow), new FrameworkPropertyMetadata(typeof(CapacitanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(CapacitanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Capacitance? Value
        {
            get { return (Capacitance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Capacitance? MinValue
        {
            get { return (Capacitance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Capacitance? MaxValue
        {
            get { return (Capacitance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public CapacitanceUnit Unit
        {
            get { return (CapacitanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Capacitance))
            {
                return "wrong type";
            }

            var qty = (Capacitance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, CapacitanceUnit unit)
        {
            return default(Capacitance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CapacitanceRow)d).OnMinValueChanged((Capacitance?)e.OldValue, (Capacitance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CapacitanceRow)d).OnMaxValueChanged((Capacitance?)e.OldValue, (Capacitance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (CapacitanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (CapacitanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (CapacitanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Capacitance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Capacitance? oldValue, Capacitance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Capacitance? oldValue, Capacitance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Capacitance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Capacitance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class CatalyticActivityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(CatalyticActivity?),
        typeof(CatalyticActivityRow),
        new FrameworkPropertyMetadata(
            default(CatalyticActivity?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(CatalyticActivity?),
            typeof(CatalyticActivityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(CatalyticActivity?),
            typeof(CatalyticActivityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(CatalyticActivityUnit),
            typeof(CatalyticActivityRow),
            new PropertyMetadata(default(CatalyticActivityUnit).SiUnit, OnUnitChanged));

        public static readonly CatalyticActivityUnit DefaultUnit = default(CatalyticActivityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static CatalyticActivityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CatalyticActivityRow), new FrameworkPropertyMetadata(typeof(CatalyticActivityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(CatalyticActivityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public CatalyticActivity? Value
        {
            get { return (CatalyticActivity?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public CatalyticActivity? MinValue
        {
            get { return (CatalyticActivity?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public CatalyticActivity? MaxValue
        {
            get { return (CatalyticActivity?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public CatalyticActivityUnit Unit
        {
            get { return (CatalyticActivityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is CatalyticActivity))
            {
                return "wrong type";
            }

            var qty = (CatalyticActivity)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, CatalyticActivityUnit unit)
        {
            return default(CatalyticActivity).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CatalyticActivityRow)d).OnMinValueChanged((CatalyticActivity?)e.OldValue, (CatalyticActivity?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CatalyticActivityRow)d).OnMaxValueChanged((CatalyticActivity?)e.OldValue, (CatalyticActivity?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (CatalyticActivityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (CatalyticActivityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (CatalyticActivityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (CatalyticActivity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(CatalyticActivity? oldValue, CatalyticActivity? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(CatalyticActivity? oldValue, CatalyticActivity? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, CatalyticActivity? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (CatalyticActivity?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class CurrentRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Current?),
        typeof(CurrentRow),
        new FrameworkPropertyMetadata(
            default(Current?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Current?),
            typeof(CurrentRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Current?),
            typeof(CurrentRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(CurrentUnit),
            typeof(CurrentRow),
            new PropertyMetadata(default(CurrentUnit).SiUnit, OnUnitChanged));

        public static readonly CurrentUnit DefaultUnit = default(CurrentUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static CurrentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentRow), new FrameworkPropertyMetadata(typeof(CurrentRow)));
            SuffixProperty.OverrideMetadata(
                typeof(CurrentRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Current? Value
        {
            get { return (Current?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Current? MinValue
        {
            get { return (Current?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Current? MaxValue
        {
            get { return (Current?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public CurrentUnit Unit
        {
            get { return (CurrentUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Current))
            {
                return "wrong type";
            }

            var qty = (Current)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, CurrentUnit unit)
        {
            return default(Current).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CurrentRow)d).OnMinValueChanged((Current?)e.OldValue, (Current?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CurrentRow)d).OnMaxValueChanged((Current?)e.OldValue, (Current?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (CurrentRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (CurrentUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (CurrentUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Current?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Current? oldValue, Current? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Current? oldValue, Current? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Current? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Current?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class DataRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Data?),
        typeof(DataRow),
        new FrameworkPropertyMetadata(
            default(Data?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Data?),
            typeof(DataRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Data?),
            typeof(DataRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(DataUnit),
            typeof(DataRow),
            new PropertyMetadata(default(DataUnit).SiUnit, OnUnitChanged));

        public static readonly DataUnit DefaultUnit = default(DataUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static DataRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataRow), new FrameworkPropertyMetadata(typeof(DataRow)));
            SuffixProperty.OverrideMetadata(
                typeof(DataRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Data? Value
        {
            get { return (Data?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Data? MinValue
        {
            get { return (Data?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Data? MaxValue
        {
            get { return (Data?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public DataUnit Unit
        {
            get { return (DataUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Data))
            {
                return "wrong type";
            }

            var qty = (Data)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, DataUnit unit)
        {
            return default(Data).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataRow)d).OnMinValueChanged((Data?)e.OldValue, (Data?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataRow)d).OnMaxValueChanged((Data?)e.OldValue, (Data?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (DataRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (DataUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (DataUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Data?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Data? oldValue, Data? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Data? oldValue, Data? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Data? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Data?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class DensityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Density?),
        typeof(DensityRow),
        new FrameworkPropertyMetadata(
            default(Density?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Density?),
            typeof(DensityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Density?),
            typeof(DensityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(DensityUnit),
            typeof(DensityRow),
            new PropertyMetadata(default(DensityUnit).SiUnit, OnUnitChanged));

        public static readonly DensityUnit DefaultUnit = default(DensityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static DensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DensityRow), new FrameworkPropertyMetadata(typeof(DensityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(DensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Density? Value
        {
            get { return (Density?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Density? MinValue
        {
            get { return (Density?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Density? MaxValue
        {
            get { return (Density?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public DensityUnit Unit
        {
            get { return (DensityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Density))
            {
                return "wrong type";
            }

            var qty = (Density)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, DensityUnit unit)
        {
            return default(Density).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DensityRow)d).OnMinValueChanged((Density?)e.OldValue, (Density?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DensityRow)d).OnMaxValueChanged((Density?)e.OldValue, (Density?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (DensityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (DensityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (DensityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Density?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Density? oldValue, Density? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Density? oldValue, Density? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Density? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Density?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class ElectricalConductanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(ElectricalConductance?),
        typeof(ElectricalConductanceRow),
        new FrameworkPropertyMetadata(
            default(ElectricalConductance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(ElectricalConductance?),
            typeof(ElectricalConductanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(ElectricalConductance?),
            typeof(ElectricalConductanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(ElectricalConductanceUnit),
            typeof(ElectricalConductanceRow),
            new PropertyMetadata(default(ElectricalConductanceUnit).SiUnit, OnUnitChanged));

        public static readonly ElectricalConductanceUnit DefaultUnit = default(ElectricalConductanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static ElectricalConductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricalConductanceRow), new FrameworkPropertyMetadata(typeof(ElectricalConductanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricalConductanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public ElectricalConductance? Value
        {
            get { return (ElectricalConductance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public ElectricalConductance? MinValue
        {
            get { return (ElectricalConductance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public ElectricalConductance? MaxValue
        {
            get { return (ElectricalConductance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public ElectricalConductanceUnit Unit
        {
            get { return (ElectricalConductanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is ElectricalConductance))
            {
                return "wrong type";
            }

            var qty = (ElectricalConductance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, ElectricalConductanceUnit unit)
        {
            return default(ElectricalConductance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ElectricalConductanceRow)d).OnMinValueChanged((ElectricalConductance?)e.OldValue, (ElectricalConductance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ElectricalConductanceRow)d).OnMaxValueChanged((ElectricalConductance?)e.OldValue, (ElectricalConductance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ElectricalConductanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (ElectricalConductanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (ElectricalConductanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (ElectricalConductance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(ElectricalConductance? oldValue, ElectricalConductance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(ElectricalConductance? oldValue, ElectricalConductance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, ElectricalConductance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (ElectricalConductance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class ElectricChargeRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(ElectricCharge?),
        typeof(ElectricChargeRow),
        new FrameworkPropertyMetadata(
            default(ElectricCharge?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(ElectricCharge?),
            typeof(ElectricChargeRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(ElectricCharge?),
            typeof(ElectricChargeRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(ElectricChargeUnit),
            typeof(ElectricChargeRow),
            new PropertyMetadata(default(ElectricChargeUnit).SiUnit, OnUnitChanged));

        public static readonly ElectricChargeUnit DefaultUnit = default(ElectricChargeUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static ElectricChargeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricChargeRow), new FrameworkPropertyMetadata(typeof(ElectricChargeRow)));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricChargeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public ElectricCharge? Value
        {
            get { return (ElectricCharge?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public ElectricCharge? MinValue
        {
            get { return (ElectricCharge?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public ElectricCharge? MaxValue
        {
            get { return (ElectricCharge?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public ElectricChargeUnit Unit
        {
            get { return (ElectricChargeUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is ElectricCharge))
            {
                return "wrong type";
            }

            var qty = (ElectricCharge)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, ElectricChargeUnit unit)
        {
            return default(ElectricCharge).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ElectricChargeRow)d).OnMinValueChanged((ElectricCharge?)e.OldValue, (ElectricCharge?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ElectricChargeRow)d).OnMaxValueChanged((ElectricCharge?)e.OldValue, (ElectricCharge?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ElectricChargeRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (ElectricChargeUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (ElectricChargeUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (ElectricCharge?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(ElectricCharge? oldValue, ElectricCharge? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(ElectricCharge? oldValue, ElectricCharge? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, ElectricCharge? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (ElectricCharge?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class EnergyRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Energy?),
        typeof(EnergyRow),
        new FrameworkPropertyMetadata(
            default(Energy?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Energy?),
            typeof(EnergyRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Energy?),
            typeof(EnergyRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(EnergyUnit),
            typeof(EnergyRow),
            new PropertyMetadata(default(EnergyUnit).SiUnit, OnUnitChanged));

        public static readonly EnergyUnit DefaultUnit = default(EnergyUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static EnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnergyRow), new FrameworkPropertyMetadata(typeof(EnergyRow)));
            SuffixProperty.OverrideMetadata(
                typeof(EnergyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Energy? Value
        {
            get { return (Energy?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Energy? MinValue
        {
            get { return (Energy?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Energy? MaxValue
        {
            get { return (Energy?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public EnergyUnit Unit
        {
            get { return (EnergyUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Energy))
            {
                return "wrong type";
            }

            var qty = (Energy)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, EnergyUnit unit)
        {
            return default(Energy).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((EnergyRow)d).OnMinValueChanged((Energy?)e.OldValue, (Energy?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((EnergyRow)d).OnMaxValueChanged((Energy?)e.OldValue, (Energy?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (EnergyRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (EnergyUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (EnergyUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Energy?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Energy? oldValue, Energy? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Energy? oldValue, Energy? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Energy? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Energy?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class FlexibilityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Flexibility?),
        typeof(FlexibilityRow),
        new FrameworkPropertyMetadata(
            default(Flexibility?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Flexibility?),
            typeof(FlexibilityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Flexibility?),
            typeof(FlexibilityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(FlexibilityUnit),
            typeof(FlexibilityRow),
            new PropertyMetadata(default(FlexibilityUnit).SiUnit, OnUnitChanged));

        public static readonly FlexibilityUnit DefaultUnit = default(FlexibilityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static FlexibilityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexibilityRow), new FrameworkPropertyMetadata(typeof(FlexibilityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(FlexibilityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Flexibility? Value
        {
            get { return (Flexibility?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Flexibility? MinValue
        {
            get { return (Flexibility?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Flexibility? MaxValue
        {
            get { return (Flexibility?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public FlexibilityUnit Unit
        {
            get { return (FlexibilityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Flexibility))
            {
                return "wrong type";
            }

            var qty = (Flexibility)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, FlexibilityUnit unit)
        {
            return default(Flexibility).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FlexibilityRow)d).OnMinValueChanged((Flexibility?)e.OldValue, (Flexibility?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FlexibilityRow)d).OnMaxValueChanged((Flexibility?)e.OldValue, (Flexibility?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (FlexibilityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (FlexibilityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (FlexibilityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Flexibility?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Flexibility? oldValue, Flexibility? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Flexibility? oldValue, Flexibility? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Flexibility? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Flexibility?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class ForceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Force?),
        typeof(ForceRow),
        new FrameworkPropertyMetadata(
            default(Force?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Force?),
            typeof(ForceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Force?),
            typeof(ForceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(ForceUnit),
            typeof(ForceRow),
            new PropertyMetadata(default(ForceUnit).SiUnit, OnUnitChanged));

        public static readonly ForceUnit DefaultUnit = default(ForceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static ForceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForceRow), new FrameworkPropertyMetadata(typeof(ForceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(ForceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Force? Value
        {
            get { return (Force?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Force? MinValue
        {
            get { return (Force?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Force? MaxValue
        {
            get { return (Force?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public ForceUnit Unit
        {
            get { return (ForceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Force))
            {
                return "wrong type";
            }

            var qty = (Force)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, ForceUnit unit)
        {
            return default(Force).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ForceRow)d).OnMinValueChanged((Force?)e.OldValue, (Force?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ForceRow)d).OnMaxValueChanged((Force?)e.OldValue, (Force?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ForceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (ForceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (ForceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Force?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Force? oldValue, Force? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Force? oldValue, Force? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Force? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Force?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class ForcePerUnitlessRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(ForcePerUnitless?),
        typeof(ForcePerUnitlessRow),
        new FrameworkPropertyMetadata(
            default(ForcePerUnitless?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(ForcePerUnitless?),
            typeof(ForcePerUnitlessRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(ForcePerUnitless?),
            typeof(ForcePerUnitlessRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(ForcePerUnitlessUnit),
            typeof(ForcePerUnitlessRow),
            new PropertyMetadata(default(ForcePerUnitlessUnit).SiUnit, OnUnitChanged));

        public static readonly ForcePerUnitlessUnit DefaultUnit = default(ForcePerUnitlessUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static ForcePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForcePerUnitlessRow), new FrameworkPropertyMetadata(typeof(ForcePerUnitlessRow)));
            SuffixProperty.OverrideMetadata(
                typeof(ForcePerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public ForcePerUnitless? Value
        {
            get { return (ForcePerUnitless?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public ForcePerUnitless? MinValue
        {
            get { return (ForcePerUnitless?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public ForcePerUnitless? MaxValue
        {
            get { return (ForcePerUnitless?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public ForcePerUnitlessUnit Unit
        {
            get { return (ForcePerUnitlessUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is ForcePerUnitless))
            {
                return "wrong type";
            }

            var qty = (ForcePerUnitless)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, ForcePerUnitlessUnit unit)
        {
            return default(ForcePerUnitless).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ForcePerUnitlessRow)d).OnMinValueChanged((ForcePerUnitless?)e.OldValue, (ForcePerUnitless?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ForcePerUnitlessRow)d).OnMaxValueChanged((ForcePerUnitless?)e.OldValue, (ForcePerUnitless?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ForcePerUnitlessRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (ForcePerUnitlessUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (ForcePerUnitlessUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (ForcePerUnitless?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(ForcePerUnitless? oldValue, ForcePerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(ForcePerUnitless? oldValue, ForcePerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, ForcePerUnitless? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (ForcePerUnitless?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class FrequencyRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Frequency?),
        typeof(FrequencyRow),
        new FrameworkPropertyMetadata(
            default(Frequency?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Frequency?),
            typeof(FrequencyRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Frequency?),
            typeof(FrequencyRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(FrequencyUnit),
            typeof(FrequencyRow),
            new PropertyMetadata(default(FrequencyUnit).SiUnit, OnUnitChanged));

        public static readonly FrequencyUnit DefaultUnit = default(FrequencyUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static FrequencyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrequencyRow), new FrameworkPropertyMetadata(typeof(FrequencyRow)));
            SuffixProperty.OverrideMetadata(
                typeof(FrequencyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Frequency? Value
        {
            get { return (Frequency?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Frequency? MinValue
        {
            get { return (Frequency?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Frequency? MaxValue
        {
            get { return (Frequency?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public FrequencyUnit Unit
        {
            get { return (FrequencyUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Frequency))
            {
                return "wrong type";
            }

            var qty = (Frequency)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, FrequencyUnit unit)
        {
            return default(Frequency).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FrequencyRow)d).OnMinValueChanged((Frequency?)e.OldValue, (Frequency?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FrequencyRow)d).OnMaxValueChanged((Frequency?)e.OldValue, (Frequency?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (FrequencyRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (FrequencyUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (FrequencyUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Frequency?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Frequency? oldValue, Frequency? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Frequency? oldValue, Frequency? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Frequency? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Frequency?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class IlluminanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Illuminance?),
        typeof(IlluminanceRow),
        new FrameworkPropertyMetadata(
            default(Illuminance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Illuminance?),
            typeof(IlluminanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Illuminance?),
            typeof(IlluminanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(IlluminanceUnit),
            typeof(IlluminanceRow),
            new PropertyMetadata(default(IlluminanceUnit).SiUnit, OnUnitChanged));

        public static readonly IlluminanceUnit DefaultUnit = default(IlluminanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static IlluminanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IlluminanceRow), new FrameworkPropertyMetadata(typeof(IlluminanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(IlluminanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Illuminance? Value
        {
            get { return (Illuminance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Illuminance? MinValue
        {
            get { return (Illuminance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Illuminance? MaxValue
        {
            get { return (Illuminance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public IlluminanceUnit Unit
        {
            get { return (IlluminanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Illuminance))
            {
                return "wrong type";
            }

            var qty = (Illuminance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, IlluminanceUnit unit)
        {
            return default(Illuminance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((IlluminanceRow)d).OnMinValueChanged((Illuminance?)e.OldValue, (Illuminance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((IlluminanceRow)d).OnMaxValueChanged((Illuminance?)e.OldValue, (Illuminance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (IlluminanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (IlluminanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (IlluminanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Illuminance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Illuminance? oldValue, Illuminance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Illuminance? oldValue, Illuminance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Illuminance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Illuminance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class InductanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Inductance?),
        typeof(InductanceRow),
        new FrameworkPropertyMetadata(
            default(Inductance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Inductance?),
            typeof(InductanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Inductance?),
            typeof(InductanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(InductanceUnit),
            typeof(InductanceRow),
            new PropertyMetadata(default(InductanceUnit).SiUnit, OnUnitChanged));

        public static readonly InductanceUnit DefaultUnit = default(InductanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static InductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InductanceRow), new FrameworkPropertyMetadata(typeof(InductanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(InductanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Inductance? Value
        {
            get { return (Inductance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Inductance? MinValue
        {
            get { return (Inductance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Inductance? MaxValue
        {
            get { return (Inductance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public InductanceUnit Unit
        {
            get { return (InductanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Inductance))
            {
                return "wrong type";
            }

            var qty = (Inductance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, InductanceUnit unit)
        {
            return default(Inductance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((InductanceRow)d).OnMinValueChanged((Inductance?)e.OldValue, (Inductance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((InductanceRow)d).OnMaxValueChanged((Inductance?)e.OldValue, (Inductance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (InductanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (InductanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (InductanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Inductance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Inductance? oldValue, Inductance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Inductance? oldValue, Inductance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Inductance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Inductance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class JerkRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Jerk?),
        typeof(JerkRow),
        new FrameworkPropertyMetadata(
            default(Jerk?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Jerk?),
            typeof(JerkRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Jerk?),
            typeof(JerkRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(JerkUnit),
            typeof(JerkRow),
            new PropertyMetadata(default(JerkUnit).SiUnit, OnUnitChanged));

        public static readonly JerkUnit DefaultUnit = default(JerkUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static JerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JerkRow), new FrameworkPropertyMetadata(typeof(JerkRow)));
            SuffixProperty.OverrideMetadata(
                typeof(JerkRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Jerk? Value
        {
            get { return (Jerk?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Jerk? MinValue
        {
            get { return (Jerk?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Jerk? MaxValue
        {
            get { return (Jerk?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public JerkUnit Unit
        {
            get { return (JerkUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Jerk))
            {
                return "wrong type";
            }

            var qty = (Jerk)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, JerkUnit unit)
        {
            return default(Jerk).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((JerkRow)d).OnMinValueChanged((Jerk?)e.OldValue, (Jerk?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((JerkRow)d).OnMaxValueChanged((Jerk?)e.OldValue, (Jerk?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (JerkRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (JerkUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (JerkUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Jerk?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Jerk? oldValue, Jerk? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Jerk? oldValue, Jerk? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Jerk? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Jerk?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class KinematicViscosityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(KinematicViscosity?),
        typeof(KinematicViscosityRow),
        new FrameworkPropertyMetadata(
            default(KinematicViscosity?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(KinematicViscosity?),
            typeof(KinematicViscosityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(KinematicViscosity?),
            typeof(KinematicViscosityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(KinematicViscosityUnit),
            typeof(KinematicViscosityRow),
            new PropertyMetadata(default(KinematicViscosityUnit).SiUnit, OnUnitChanged));

        public static readonly KinematicViscosityUnit DefaultUnit = default(KinematicViscosityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static KinematicViscosityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KinematicViscosityRow), new FrameworkPropertyMetadata(typeof(KinematicViscosityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(KinematicViscosityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public KinematicViscosity? Value
        {
            get { return (KinematicViscosity?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public KinematicViscosity? MinValue
        {
            get { return (KinematicViscosity?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public KinematicViscosity? MaxValue
        {
            get { return (KinematicViscosity?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public KinematicViscosityUnit Unit
        {
            get { return (KinematicViscosityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is KinematicViscosity))
            {
                return "wrong type";
            }

            var qty = (KinematicViscosity)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, KinematicViscosityUnit unit)
        {
            return default(KinematicViscosity).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((KinematicViscosityRow)d).OnMinValueChanged((KinematicViscosity?)e.OldValue, (KinematicViscosity?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((KinematicViscosityRow)d).OnMaxValueChanged((KinematicViscosity?)e.OldValue, (KinematicViscosity?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (KinematicViscosityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (KinematicViscosityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (KinematicViscosityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (KinematicViscosity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(KinematicViscosity? oldValue, KinematicViscosity? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(KinematicViscosity? oldValue, KinematicViscosity? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, KinematicViscosity? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (KinematicViscosity?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class LengthRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Length?),
        typeof(LengthRow),
        new FrameworkPropertyMetadata(
            default(Length?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Length?),
            typeof(LengthRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Length?),
            typeof(LengthRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(LengthUnit),
            typeof(LengthRow),
            new PropertyMetadata(default(LengthUnit).SiUnit, OnUnitChanged));

        public static readonly LengthUnit DefaultUnit = default(LengthUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static LengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthRow), new FrameworkPropertyMetadata(typeof(LengthRow)));
            SuffixProperty.OverrideMetadata(
                typeof(LengthRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Length? Value
        {
            get { return (Length?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Length? MinValue
        {
            get { return (Length?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Length? MaxValue
        {
            get { return (Length?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public LengthUnit Unit
        {
            get { return (LengthUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Length))
            {
                return "wrong type";
            }

            var qty = (Length)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, LengthUnit unit)
        {
            return default(Length).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LengthRow)d).OnMinValueChanged((Length?)e.OldValue, (Length?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LengthRow)d).OnMaxValueChanged((Length?)e.OldValue, (Length?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (LengthRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (LengthUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (LengthUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Length?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Length? oldValue, Length? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Length? oldValue, Length? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Length? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Length?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class LengthPerUnitlessRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(LengthPerUnitless?),
        typeof(LengthPerUnitlessRow),
        new FrameworkPropertyMetadata(
            default(LengthPerUnitless?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(LengthPerUnitless?),
            typeof(LengthPerUnitlessRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(LengthPerUnitless?),
            typeof(LengthPerUnitlessRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(LengthPerUnitlessUnit),
            typeof(LengthPerUnitlessRow),
            new PropertyMetadata(default(LengthPerUnitlessUnit).SiUnit, OnUnitChanged));

        public static readonly LengthPerUnitlessUnit DefaultUnit = default(LengthPerUnitlessUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static LengthPerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthPerUnitlessRow), new FrameworkPropertyMetadata(typeof(LengthPerUnitlessRow)));
            SuffixProperty.OverrideMetadata(
                typeof(LengthPerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public LengthPerUnitless? Value
        {
            get { return (LengthPerUnitless?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public LengthPerUnitless? MinValue
        {
            get { return (LengthPerUnitless?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public LengthPerUnitless? MaxValue
        {
            get { return (LengthPerUnitless?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public LengthPerUnitlessUnit Unit
        {
            get { return (LengthPerUnitlessUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is LengthPerUnitless))
            {
                return "wrong type";
            }

            var qty = (LengthPerUnitless)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, LengthPerUnitlessUnit unit)
        {
            return default(LengthPerUnitless).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LengthPerUnitlessRow)d).OnMinValueChanged((LengthPerUnitless?)e.OldValue, (LengthPerUnitless?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LengthPerUnitlessRow)d).OnMaxValueChanged((LengthPerUnitless?)e.OldValue, (LengthPerUnitless?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (LengthPerUnitlessRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (LengthPerUnitlessUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (LengthPerUnitlessUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (LengthPerUnitless?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(LengthPerUnitless? oldValue, LengthPerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(LengthPerUnitless? oldValue, LengthPerUnitless? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, LengthPerUnitless? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (LengthPerUnitless?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class LuminousFluxRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(LuminousFlux?),
        typeof(LuminousFluxRow),
        new FrameworkPropertyMetadata(
            default(LuminousFlux?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(LuminousFlux?),
            typeof(LuminousFluxRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(LuminousFlux?),
            typeof(LuminousFluxRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(LuminousFluxUnit),
            typeof(LuminousFluxRow),
            new PropertyMetadata(default(LuminousFluxUnit).SiUnit, OnUnitChanged));

        public static readonly LuminousFluxUnit DefaultUnit = default(LuminousFluxUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static LuminousFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousFluxRow), new FrameworkPropertyMetadata(typeof(LuminousFluxRow)));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousFluxRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public LuminousFlux? Value
        {
            get { return (LuminousFlux?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public LuminousFlux? MinValue
        {
            get { return (LuminousFlux?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public LuminousFlux? MaxValue
        {
            get { return (LuminousFlux?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public LuminousFluxUnit Unit
        {
            get { return (LuminousFluxUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is LuminousFlux))
            {
                return "wrong type";
            }

            var qty = (LuminousFlux)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, LuminousFluxUnit unit)
        {
            return default(LuminousFlux).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LuminousFluxRow)d).OnMinValueChanged((LuminousFlux?)e.OldValue, (LuminousFlux?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LuminousFluxRow)d).OnMaxValueChanged((LuminousFlux?)e.OldValue, (LuminousFlux?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (LuminousFluxRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (LuminousFluxUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (LuminousFluxUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (LuminousFlux?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(LuminousFlux? oldValue, LuminousFlux? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(LuminousFlux? oldValue, LuminousFlux? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, LuminousFlux? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (LuminousFlux?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class LuminousIntensityRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(LuminousIntensity?),
        typeof(LuminousIntensityRow),
        new FrameworkPropertyMetadata(
            default(LuminousIntensity?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(LuminousIntensity?),
            typeof(LuminousIntensityRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(LuminousIntensity?),
            typeof(LuminousIntensityRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(LuminousIntensityUnit),
            typeof(LuminousIntensityRow),
            new PropertyMetadata(default(LuminousIntensityUnit).SiUnit, OnUnitChanged));

        public static readonly LuminousIntensityUnit DefaultUnit = default(LuminousIntensityUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static LuminousIntensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousIntensityRow), new FrameworkPropertyMetadata(typeof(LuminousIntensityRow)));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousIntensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public LuminousIntensity? Value
        {
            get { return (LuminousIntensity?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public LuminousIntensity? MinValue
        {
            get { return (LuminousIntensity?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public LuminousIntensity? MaxValue
        {
            get { return (LuminousIntensity?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public LuminousIntensityUnit Unit
        {
            get { return (LuminousIntensityUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is LuminousIntensity))
            {
                return "wrong type";
            }

            var qty = (LuminousIntensity)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, LuminousIntensityUnit unit)
        {
            return default(LuminousIntensity).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LuminousIntensityRow)d).OnMinValueChanged((LuminousIntensity?)e.OldValue, (LuminousIntensity?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LuminousIntensityRow)d).OnMaxValueChanged((LuminousIntensity?)e.OldValue, (LuminousIntensity?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (LuminousIntensityRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (LuminousIntensityUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (LuminousIntensityUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (LuminousIntensity?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(LuminousIntensity? oldValue, LuminousIntensity? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(LuminousIntensity? oldValue, LuminousIntensity? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, LuminousIntensity? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (LuminousIntensity?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class MagneticFieldStrengthRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(MagneticFieldStrength?),
        typeof(MagneticFieldStrengthRow),
        new FrameworkPropertyMetadata(
            default(MagneticFieldStrength?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(MagneticFieldStrength?),
            typeof(MagneticFieldStrengthRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(MagneticFieldStrength?),
            typeof(MagneticFieldStrengthRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(MagneticFieldStrengthUnit),
            typeof(MagneticFieldStrengthRow),
            new PropertyMetadata(default(MagneticFieldStrengthUnit).SiUnit, OnUnitChanged));

        public static readonly MagneticFieldStrengthUnit DefaultUnit = default(MagneticFieldStrengthUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static MagneticFieldStrengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFieldStrengthRow), new FrameworkPropertyMetadata(typeof(MagneticFieldStrengthRow)));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFieldStrengthRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public MagneticFieldStrength? Value
        {
            get { return (MagneticFieldStrength?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public MagneticFieldStrength? MinValue
        {
            get { return (MagneticFieldStrength?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public MagneticFieldStrength? MaxValue
        {
            get { return (MagneticFieldStrength?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public MagneticFieldStrengthUnit Unit
        {
            get { return (MagneticFieldStrengthUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is MagneticFieldStrength))
            {
                return "wrong type";
            }

            var qty = (MagneticFieldStrength)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, MagneticFieldStrengthUnit unit)
        {
            return default(MagneticFieldStrength).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MagneticFieldStrengthRow)d).OnMinValueChanged((MagneticFieldStrength?)e.OldValue, (MagneticFieldStrength?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MagneticFieldStrengthRow)d).OnMaxValueChanged((MagneticFieldStrength?)e.OldValue, (MagneticFieldStrength?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (MagneticFieldStrengthRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (MagneticFieldStrengthUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (MagneticFieldStrengthUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (MagneticFieldStrength?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(MagneticFieldStrength? oldValue, MagneticFieldStrength? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(MagneticFieldStrength? oldValue, MagneticFieldStrength? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, MagneticFieldStrength? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (MagneticFieldStrength?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class MagneticFluxRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(MagneticFlux?),
        typeof(MagneticFluxRow),
        new FrameworkPropertyMetadata(
            default(MagneticFlux?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(MagneticFlux?),
            typeof(MagneticFluxRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(MagneticFlux?),
            typeof(MagneticFluxRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(MagneticFluxUnit),
            typeof(MagneticFluxRow),
            new PropertyMetadata(default(MagneticFluxUnit).SiUnit, OnUnitChanged));

        public static readonly MagneticFluxUnit DefaultUnit = default(MagneticFluxUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static MagneticFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFluxRow), new FrameworkPropertyMetadata(typeof(MagneticFluxRow)));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFluxRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public MagneticFlux? Value
        {
            get { return (MagneticFlux?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public MagneticFlux? MinValue
        {
            get { return (MagneticFlux?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public MagneticFlux? MaxValue
        {
            get { return (MagneticFlux?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public MagneticFluxUnit Unit
        {
            get { return (MagneticFluxUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is MagneticFlux))
            {
                return "wrong type";
            }

            var qty = (MagneticFlux)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, MagneticFluxUnit unit)
        {
            return default(MagneticFlux).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MagneticFluxRow)d).OnMinValueChanged((MagneticFlux?)e.OldValue, (MagneticFlux?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MagneticFluxRow)d).OnMaxValueChanged((MagneticFlux?)e.OldValue, (MagneticFlux?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (MagneticFluxRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (MagneticFluxUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (MagneticFluxUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (MagneticFlux?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(MagneticFlux? oldValue, MagneticFlux? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(MagneticFlux? oldValue, MagneticFlux? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, MagneticFlux? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (MagneticFlux?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class MassRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Mass?),
        typeof(MassRow),
        new FrameworkPropertyMetadata(
            default(Mass?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Mass?),
            typeof(MassRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Mass?),
            typeof(MassRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(MassUnit),
            typeof(MassRow),
            new PropertyMetadata(default(MassUnit).SiUnit, OnUnitChanged));

        public static readonly MassUnit DefaultUnit = default(MassUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static MassRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassRow), new FrameworkPropertyMetadata(typeof(MassRow)));
            SuffixProperty.OverrideMetadata(
                typeof(MassRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Mass? Value
        {
            get { return (Mass?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Mass? MinValue
        {
            get { return (Mass?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Mass? MaxValue
        {
            get { return (Mass?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public MassUnit Unit
        {
            get { return (MassUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Mass))
            {
                return "wrong type";
            }

            var qty = (Mass)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, MassUnit unit)
        {
            return default(Mass).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MassRow)d).OnMinValueChanged((Mass?)e.OldValue, (Mass?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MassRow)d).OnMaxValueChanged((Mass?)e.OldValue, (Mass?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (MassRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (MassUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (MassUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Mass?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Mass? oldValue, Mass? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Mass? oldValue, Mass? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Mass? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Mass?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class MassFlowRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(MassFlow?),
        typeof(MassFlowRow),
        new FrameworkPropertyMetadata(
            default(MassFlow?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(MassFlow?),
            typeof(MassFlowRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(MassFlow?),
            typeof(MassFlowRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(MassFlowUnit),
            typeof(MassFlowRow),
            new PropertyMetadata(default(MassFlowUnit).SiUnit, OnUnitChanged));

        public static readonly MassFlowUnit DefaultUnit = default(MassFlowUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static MassFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassFlowRow), new FrameworkPropertyMetadata(typeof(MassFlowRow)));
            SuffixProperty.OverrideMetadata(
                typeof(MassFlowRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public MassFlow? Value
        {
            get { return (MassFlow?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public MassFlow? MinValue
        {
            get { return (MassFlow?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public MassFlow? MaxValue
        {
            get { return (MassFlow?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public MassFlowUnit Unit
        {
            get { return (MassFlowUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is MassFlow))
            {
                return "wrong type";
            }

            var qty = (MassFlow)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, MassFlowUnit unit)
        {
            return default(MassFlow).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MassFlowRow)d).OnMinValueChanged((MassFlow?)e.OldValue, (MassFlow?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MassFlowRow)d).OnMaxValueChanged((MassFlow?)e.OldValue, (MassFlow?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (MassFlowRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (MassFlowUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (MassFlowUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (MassFlow?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(MassFlow? oldValue, MassFlow? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(MassFlow? oldValue, MassFlow? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, MassFlow? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (MassFlow?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class MomentumRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Momentum?),
        typeof(MomentumRow),
        new FrameworkPropertyMetadata(
            default(Momentum?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Momentum?),
            typeof(MomentumRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Momentum?),
            typeof(MomentumRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(MomentumUnit),
            typeof(MomentumRow),
            new PropertyMetadata(default(MomentumUnit).SiUnit, OnUnitChanged));

        public static readonly MomentumUnit DefaultUnit = default(MomentumUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static MomentumRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MomentumRow), new FrameworkPropertyMetadata(typeof(MomentumRow)));
            SuffixProperty.OverrideMetadata(
                typeof(MomentumRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Momentum? Value
        {
            get { return (Momentum?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Momentum? MinValue
        {
            get { return (Momentum?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Momentum? MaxValue
        {
            get { return (Momentum?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public MomentumUnit Unit
        {
            get { return (MomentumUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Momentum))
            {
                return "wrong type";
            }

            var qty = (Momentum)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, MomentumUnit unit)
        {
            return default(Momentum).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MomentumRow)d).OnMinValueChanged((Momentum?)e.OldValue, (Momentum?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MomentumRow)d).OnMaxValueChanged((Momentum?)e.OldValue, (Momentum?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (MomentumRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (MomentumUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (MomentumUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Momentum?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Momentum? oldValue, Momentum? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Momentum? oldValue, Momentum? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Momentum? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Momentum?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class PowerRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Power?),
        typeof(PowerRow),
        new FrameworkPropertyMetadata(
            default(Power?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Power?),
            typeof(PowerRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Power?),
            typeof(PowerRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(PowerUnit),
            typeof(PowerRow),
            new PropertyMetadata(default(PowerUnit).SiUnit, OnUnitChanged));

        public static readonly PowerUnit DefaultUnit = default(PowerUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static PowerRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerRow), new FrameworkPropertyMetadata(typeof(PowerRow)));
            SuffixProperty.OverrideMetadata(
                typeof(PowerRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Power? Value
        {
            get { return (Power?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Power? MinValue
        {
            get { return (Power?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Power? MaxValue
        {
            get { return (Power?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public PowerUnit Unit
        {
            get { return (PowerUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Power))
            {
                return "wrong type";
            }

            var qty = (Power)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, PowerUnit unit)
        {
            return default(Power).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PowerRow)d).OnMinValueChanged((Power?)e.OldValue, (Power?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PowerRow)d).OnMaxValueChanged((Power?)e.OldValue, (Power?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (PowerRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (PowerUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (PowerUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Power?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Power? oldValue, Power? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Power? oldValue, Power? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Power? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Power?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class PressureRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Pressure?),
        typeof(PressureRow),
        new FrameworkPropertyMetadata(
            default(Pressure?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Pressure?),
            typeof(PressureRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Pressure?),
            typeof(PressureRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(PressureUnit),
            typeof(PressureRow),
            new PropertyMetadata(default(PressureUnit).SiUnit, OnUnitChanged));

        public static readonly PressureUnit DefaultUnit = default(PressureUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static PressureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PressureRow), new FrameworkPropertyMetadata(typeof(PressureRow)));
            SuffixProperty.OverrideMetadata(
                typeof(PressureRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Pressure? Value
        {
            get { return (Pressure?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Pressure? MinValue
        {
            get { return (Pressure?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Pressure? MaxValue
        {
            get { return (Pressure?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public PressureUnit Unit
        {
            get { return (PressureUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Pressure))
            {
                return "wrong type";
            }

            var qty = (Pressure)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, PressureUnit unit)
        {
            return default(Pressure).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PressureRow)d).OnMinValueChanged((Pressure?)e.OldValue, (Pressure?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PressureRow)d).OnMaxValueChanged((Pressure?)e.OldValue, (Pressure?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (PressureRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (PressureUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (PressureUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Pressure?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Pressure? oldValue, Pressure? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Pressure? oldValue, Pressure? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Pressure? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Pressure?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class ResistanceRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Resistance?),
        typeof(ResistanceRow),
        new FrameworkPropertyMetadata(
            default(Resistance?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Resistance?),
            typeof(ResistanceRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Resistance?),
            typeof(ResistanceRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(ResistanceUnit),
            typeof(ResistanceRow),
            new PropertyMetadata(default(ResistanceUnit).SiUnit, OnUnitChanged));

        public static readonly ResistanceUnit DefaultUnit = default(ResistanceUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static ResistanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResistanceRow), new FrameworkPropertyMetadata(typeof(ResistanceRow)));
            SuffixProperty.OverrideMetadata(
                typeof(ResistanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Resistance? Value
        {
            get { return (Resistance?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Resistance? MinValue
        {
            get { return (Resistance?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Resistance? MaxValue
        {
            get { return (Resistance?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public ResistanceUnit Unit
        {
            get { return (ResistanceUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Resistance))
            {
                return "wrong type";
            }

            var qty = (Resistance)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, ResistanceUnit unit)
        {
            return default(Resistance).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ResistanceRow)d).OnMinValueChanged((Resistance?)e.OldValue, (Resistance?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ResistanceRow)d).OnMaxValueChanged((Resistance?)e.OldValue, (Resistance?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (ResistanceRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (ResistanceUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (ResistanceUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Resistance?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Resistance? oldValue, Resistance? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Resistance? oldValue, Resistance? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Resistance? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Resistance?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class SolidAngleRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(SolidAngle?),
        typeof(SolidAngleRow),
        new FrameworkPropertyMetadata(
            default(SolidAngle?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(SolidAngle?),
            typeof(SolidAngleRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(SolidAngle?),
            typeof(SolidAngleRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(SolidAngleUnit),
            typeof(SolidAngleRow),
            new PropertyMetadata(default(SolidAngleUnit).SiUnit, OnUnitChanged));

        public static readonly SolidAngleUnit DefaultUnit = default(SolidAngleUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static SolidAngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolidAngleRow), new FrameworkPropertyMetadata(typeof(SolidAngleRow)));
            SuffixProperty.OverrideMetadata(
                typeof(SolidAngleRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public SolidAngle? Value
        {
            get { return (SolidAngle?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public SolidAngle? MinValue
        {
            get { return (SolidAngle?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public SolidAngle? MaxValue
        {
            get { return (SolidAngle?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public SolidAngleUnit Unit
        {
            get { return (SolidAngleUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is SolidAngle))
            {
                return "wrong type";
            }

            var qty = (SolidAngle)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, SolidAngleUnit unit)
        {
            return default(SolidAngle).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SolidAngleRow)d).OnMinValueChanged((SolidAngle?)e.OldValue, (SolidAngle?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SolidAngleRow)d).OnMaxValueChanged((SolidAngle?)e.OldValue, (SolidAngle?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (SolidAngleRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (SolidAngleUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (SolidAngleUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (SolidAngle?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(SolidAngle? oldValue, SolidAngle? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(SolidAngle? oldValue, SolidAngle? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, SolidAngle? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (SolidAngle?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class SpecificEnergyRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(SpecificEnergy?),
        typeof(SpecificEnergyRow),
        new FrameworkPropertyMetadata(
            default(SpecificEnergy?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(SpecificEnergy?),
            typeof(SpecificEnergyRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(SpecificEnergy?),
            typeof(SpecificEnergyRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(SpecificEnergyUnit),
            typeof(SpecificEnergyRow),
            new PropertyMetadata(default(SpecificEnergyUnit).SiUnit, OnUnitChanged));

        public static readonly SpecificEnergyUnit DefaultUnit = default(SpecificEnergyUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static SpecificEnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificEnergyRow), new FrameworkPropertyMetadata(typeof(SpecificEnergyRow)));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificEnergyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public SpecificEnergy? Value
        {
            get { return (SpecificEnergy?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public SpecificEnergy? MinValue
        {
            get { return (SpecificEnergy?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public SpecificEnergy? MaxValue
        {
            get { return (SpecificEnergy?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public SpecificEnergyUnit Unit
        {
            get { return (SpecificEnergyUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is SpecificEnergy))
            {
                return "wrong type";
            }

            var qty = (SpecificEnergy)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, SpecificEnergyUnit unit)
        {
            return default(SpecificEnergy).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpecificEnergyRow)d).OnMinValueChanged((SpecificEnergy?)e.OldValue, (SpecificEnergy?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpecificEnergyRow)d).OnMaxValueChanged((SpecificEnergy?)e.OldValue, (SpecificEnergy?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (SpecificEnergyRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (SpecificEnergyUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (SpecificEnergyUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (SpecificEnergy?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(SpecificEnergy? oldValue, SpecificEnergy? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(SpecificEnergy? oldValue, SpecificEnergy? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, SpecificEnergy? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (SpecificEnergy?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class SpecificVolumeRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(SpecificVolume?),
        typeof(SpecificVolumeRow),
        new FrameworkPropertyMetadata(
            default(SpecificVolume?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(SpecificVolume?),
            typeof(SpecificVolumeRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(SpecificVolume?),
            typeof(SpecificVolumeRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(SpecificVolumeUnit),
            typeof(SpecificVolumeRow),
            new PropertyMetadata(default(SpecificVolumeUnit).SiUnit, OnUnitChanged));

        public static readonly SpecificVolumeUnit DefaultUnit = default(SpecificVolumeUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static SpecificVolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificVolumeRow), new FrameworkPropertyMetadata(typeof(SpecificVolumeRow)));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificVolumeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public SpecificVolume? Value
        {
            get { return (SpecificVolume?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public SpecificVolume? MinValue
        {
            get { return (SpecificVolume?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public SpecificVolume? MaxValue
        {
            get { return (SpecificVolume?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public SpecificVolumeUnit Unit
        {
            get { return (SpecificVolumeUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is SpecificVolume))
            {
                return "wrong type";
            }

            var qty = (SpecificVolume)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, SpecificVolumeUnit unit)
        {
            return default(SpecificVolume).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpecificVolumeRow)d).OnMinValueChanged((SpecificVolume?)e.OldValue, (SpecificVolume?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpecificVolumeRow)d).OnMaxValueChanged((SpecificVolume?)e.OldValue, (SpecificVolume?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (SpecificVolumeRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (SpecificVolumeUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (SpecificVolumeUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (SpecificVolume?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(SpecificVolume? oldValue, SpecificVolume? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(SpecificVolume? oldValue, SpecificVolume? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, SpecificVolume? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (SpecificVolume?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class SpeedRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Speed?),
        typeof(SpeedRow),
        new FrameworkPropertyMetadata(
            default(Speed?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Speed?),
            typeof(SpeedRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Speed?),
            typeof(SpeedRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(SpeedUnit),
            typeof(SpeedRow),
            new PropertyMetadata(default(SpeedUnit).SiUnit, OnUnitChanged));

        public static readonly SpeedUnit DefaultUnit = default(SpeedUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static SpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpeedRow), new FrameworkPropertyMetadata(typeof(SpeedRow)));
            SuffixProperty.OverrideMetadata(
                typeof(SpeedRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Speed? Value
        {
            get { return (Speed?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Speed? MinValue
        {
            get { return (Speed?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Speed? MaxValue
        {
            get { return (Speed?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public SpeedUnit Unit
        {
            get { return (SpeedUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Speed))
            {
                return "wrong type";
            }

            var qty = (Speed)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, SpeedUnit unit)
        {
            return default(Speed).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpeedRow)d).OnMinValueChanged((Speed?)e.OldValue, (Speed?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpeedRow)d).OnMaxValueChanged((Speed?)e.OldValue, (Speed?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (SpeedRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (SpeedUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (SpeedUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Speed?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Speed? oldValue, Speed? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Speed? oldValue, Speed? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Speed? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Speed?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class StiffnessRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Stiffness?),
        typeof(StiffnessRow),
        new FrameworkPropertyMetadata(
            default(Stiffness?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Stiffness?),
            typeof(StiffnessRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Stiffness?),
            typeof(StiffnessRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(StiffnessUnit),
            typeof(StiffnessRow),
            new PropertyMetadata(default(StiffnessUnit).SiUnit, OnUnitChanged));

        public static readonly StiffnessUnit DefaultUnit = default(StiffnessUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static StiffnessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StiffnessRow), new FrameworkPropertyMetadata(typeof(StiffnessRow)));
            SuffixProperty.OverrideMetadata(
                typeof(StiffnessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Stiffness? Value
        {
            get { return (Stiffness?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Stiffness? MinValue
        {
            get { return (Stiffness?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Stiffness? MaxValue
        {
            get { return (Stiffness?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public StiffnessUnit Unit
        {
            get { return (StiffnessUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Stiffness))
            {
                return "wrong type";
            }

            var qty = (Stiffness)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, StiffnessUnit unit)
        {
            return default(Stiffness).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((StiffnessRow)d).OnMinValueChanged((Stiffness?)e.OldValue, (Stiffness?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((StiffnessRow)d).OnMaxValueChanged((Stiffness?)e.OldValue, (Stiffness?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (StiffnessRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (StiffnessUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (StiffnessUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Stiffness?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Stiffness? oldValue, Stiffness? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Stiffness? oldValue, Stiffness? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Stiffness? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Stiffness?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class TemperatureRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Temperature?),
        typeof(TemperatureRow),
        new FrameworkPropertyMetadata(
            default(Temperature?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Temperature?),
            typeof(TemperatureRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Temperature?),
            typeof(TemperatureRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TemperatureUnit),
            typeof(TemperatureRow),
            new PropertyMetadata(default(TemperatureUnit).SiUnit, OnUnitChanged));

        public static readonly TemperatureUnit DefaultUnit = default(TemperatureUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static TemperatureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TemperatureRow), new FrameworkPropertyMetadata(typeof(TemperatureRow)));
            SuffixProperty.OverrideMetadata(
                typeof(TemperatureRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Temperature? Value
        {
            get { return (Temperature?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Temperature? MinValue
        {
            get { return (Temperature?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Temperature? MaxValue
        {
            get { return (Temperature?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public TemperatureUnit Unit
        {
            get { return (TemperatureUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Temperature))
            {
                return "wrong type";
            }

            var qty = (Temperature)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, TemperatureUnit unit)
        {
            return default(Temperature).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TemperatureRow)d).OnMinValueChanged((Temperature?)e.OldValue, (Temperature?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TemperatureRow)d).OnMaxValueChanged((Temperature?)e.OldValue, (Temperature?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (TemperatureRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (TemperatureUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (TemperatureUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Temperature?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Temperature? oldValue, Temperature? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Temperature? oldValue, Temperature? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Temperature? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Temperature?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class TimeRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Time?),
        typeof(TimeRow),
        new FrameworkPropertyMetadata(
            default(Time?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Time?),
            typeof(TimeRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Time?),
            typeof(TimeRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TimeUnit),
            typeof(TimeRow),
            new PropertyMetadata(default(TimeUnit).SiUnit, OnUnitChanged));

        public static readonly TimeUnit DefaultUnit = default(TimeUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static TimeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeRow), new FrameworkPropertyMetadata(typeof(TimeRow)));
            SuffixProperty.OverrideMetadata(
                typeof(TimeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Time? Value
        {
            get { return (Time?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Time? MinValue
        {
            get { return (Time?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Time? MaxValue
        {
            get { return (Time?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public TimeUnit Unit
        {
            get { return (TimeUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Time))
            {
                return "wrong type";
            }

            var qty = (Time)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, TimeUnit unit)
        {
            return default(Time).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TimeRow)d).OnMinValueChanged((Time?)e.OldValue, (Time?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TimeRow)d).OnMaxValueChanged((Time?)e.OldValue, (Time?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (TimeRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (TimeUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (TimeUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Time?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Time? oldValue, Time? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Time? oldValue, Time? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Time? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Time?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class TorqueRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Torque?),
        typeof(TorqueRow),
        new FrameworkPropertyMetadata(
            default(Torque?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Torque?),
            typeof(TorqueRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Torque?),
            typeof(TorqueRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TorqueUnit),
            typeof(TorqueRow),
            new PropertyMetadata(default(TorqueUnit).SiUnit, OnUnitChanged));

        public static readonly TorqueUnit DefaultUnit = default(TorqueUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static TorqueRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TorqueRow), new FrameworkPropertyMetadata(typeof(TorqueRow)));
            SuffixProperty.OverrideMetadata(
                typeof(TorqueRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Torque? Value
        {
            get { return (Torque?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Torque? MinValue
        {
            get { return (Torque?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Torque? MaxValue
        {
            get { return (Torque?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public TorqueUnit Unit
        {
            get { return (TorqueUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Torque))
            {
                return "wrong type";
            }

            var qty = (Torque)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, TorqueUnit unit)
        {
            return default(Torque).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TorqueRow)d).OnMinValueChanged((Torque?)e.OldValue, (Torque?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TorqueRow)d).OnMaxValueChanged((Torque?)e.OldValue, (Torque?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (TorqueRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (TorqueUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (TorqueUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Torque?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Torque? oldValue, Torque? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Torque? oldValue, Torque? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Torque? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Torque?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class UnitlessRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Unitless?),
        typeof(UnitlessRow),
        new FrameworkPropertyMetadata(
            default(Unitless?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Unitless?),
            typeof(UnitlessRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Unitless?),
            typeof(UnitlessRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(UnitlessUnit),
            typeof(UnitlessRow),
            new PropertyMetadata(default(UnitlessUnit).SiUnit, OnUnitChanged));

        public static readonly UnitlessUnit DefaultUnit = default(UnitlessUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static UnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitlessRow), new FrameworkPropertyMetadata(typeof(UnitlessRow)));
            SuffixProperty.OverrideMetadata(
                typeof(UnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Unitless? Value
        {
            get { return (Unitless?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Unitless? MinValue
        {
            get { return (Unitless?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Unitless? MaxValue
        {
            get { return (Unitless?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public UnitlessUnit Unit
        {
            get { return (UnitlessUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Unitless))
            {
                return "wrong type";
            }

            var qty = (Unitless)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, UnitlessUnit unit)
        {
            return default(Unitless).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitlessRow)d).OnMinValueChanged((Unitless?)e.OldValue, (Unitless?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitlessRow)d).OnMaxValueChanged((Unitless?)e.OldValue, (Unitless?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (UnitlessRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (UnitlessUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (UnitlessUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Unitless?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Unitless? oldValue, Unitless? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Unitless? oldValue, Unitless? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Unitless? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Unitless?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class VoltageRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Voltage?),
        typeof(VoltageRow),
        new FrameworkPropertyMetadata(
            default(Voltage?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Voltage?),
            typeof(VoltageRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Voltage?),
            typeof(VoltageRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(VoltageUnit),
            typeof(VoltageRow),
            new PropertyMetadata(default(VoltageUnit).SiUnit, OnUnitChanged));

        public static readonly VoltageUnit DefaultUnit = default(VoltageUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static VoltageRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoltageRow), new FrameworkPropertyMetadata(typeof(VoltageRow)));
            SuffixProperty.OverrideMetadata(
                typeof(VoltageRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Voltage? Value
        {
            get { return (Voltage?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Voltage? MinValue
        {
            get { return (Voltage?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Voltage? MaxValue
        {
            get { return (Voltage?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public VoltageUnit Unit
        {
            get { return (VoltageUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Voltage))
            {
                return "wrong type";
            }

            var qty = (Voltage)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, VoltageUnit unit)
        {
            return default(Voltage).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VoltageRow)d).OnMinValueChanged((Voltage?)e.OldValue, (Voltage?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VoltageRow)d).OnMaxValueChanged((Voltage?)e.OldValue, (Voltage?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (VoltageRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (VoltageUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (VoltageUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Voltage?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Voltage? oldValue, Voltage? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Voltage? oldValue, Voltage? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Voltage? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Voltage?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class VolumeRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Volume?),
        typeof(VolumeRow),
        new FrameworkPropertyMetadata(
            default(Volume?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Volume?),
            typeof(VolumeRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Volume?),
            typeof(VolumeRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(VolumeUnit),
            typeof(VolumeRow),
            new PropertyMetadata(default(VolumeUnit).SiUnit, OnUnitChanged));

        public static readonly VolumeUnit DefaultUnit = default(VolumeUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static VolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeRow), new FrameworkPropertyMetadata(typeof(VolumeRow)));
            SuffixProperty.OverrideMetadata(
                typeof(VolumeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Volume? Value
        {
            get { return (Volume?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Volume? MinValue
        {
            get { return (Volume?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Volume? MaxValue
        {
            get { return (Volume?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public VolumeUnit Unit
        {
            get { return (VolumeUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Volume))
            {
                return "wrong type";
            }

            var qty = (Volume)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, VolumeUnit unit)
        {
            return default(Volume).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VolumeRow)d).OnMinValueChanged((Volume?)e.OldValue, (Volume?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VolumeRow)d).OnMaxValueChanged((Volume?)e.OldValue, (Volume?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (VolumeRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (VolumeUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (VolumeUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Volume?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Volume? oldValue, Volume? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Volume? oldValue, Volume? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Volume? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Volume?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class VolumetricFlowRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(VolumetricFlow?),
        typeof(VolumetricFlowRow),
        new FrameworkPropertyMetadata(
            default(VolumetricFlow?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(VolumetricFlow?),
            typeof(VolumetricFlowRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(VolumetricFlow?),
            typeof(VolumetricFlowRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(VolumetricFlowUnit),
            typeof(VolumetricFlowRow),
            new PropertyMetadata(default(VolumetricFlowUnit).SiUnit, OnUnitChanged));

        public static readonly VolumetricFlowUnit DefaultUnit = default(VolumetricFlowUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static VolumetricFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumetricFlowRow), new FrameworkPropertyMetadata(typeof(VolumetricFlowRow)));
            SuffixProperty.OverrideMetadata(
                typeof(VolumetricFlowRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public VolumetricFlow? Value
        {
            get { return (VolumetricFlow?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public VolumetricFlow? MinValue
        {
            get { return (VolumetricFlow?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public VolumetricFlow? MaxValue
        {
            get { return (VolumetricFlow?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public VolumetricFlowUnit Unit
        {
            get { return (VolumetricFlowUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is VolumetricFlow))
            {
                return "wrong type";
            }

            var qty = (VolumetricFlow)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, VolumetricFlowUnit unit)
        {
            return default(VolumetricFlow).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VolumetricFlowRow)d).OnMinValueChanged((VolumetricFlow?)e.OldValue, (VolumetricFlow?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VolumetricFlowRow)d).OnMaxValueChanged((VolumetricFlow?)e.OldValue, (VolumetricFlow?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (VolumetricFlowRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (VolumetricFlowUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (VolumetricFlowUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (VolumetricFlow?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(VolumetricFlow? oldValue, VolumetricFlow? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(VolumetricFlow? oldValue, VolumetricFlow? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, VolumetricFlow? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (VolumetricFlow?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }

    public class WavenumberRow : UnitRowGeneric, IQuantityFormatter
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        "Value",
        typeof(Wavenumber?),
        typeof(WavenumberRow),
        new FrameworkPropertyMetadata(
            default(Wavenumber?),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged,
            null,
            true,
            UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(Wavenumber?),
            typeof(WavenumberRow),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(Wavenumber?),
            typeof(WavenumberRow),
            new PropertyMetadata(null, OnMaxValueChanged));

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(WavenumberUnit),
            typeof(WavenumberRow),
            new PropertyMetadata(default(WavenumberUnit).SiUnit, OnUnitChanged));

        public static readonly WavenumberUnit DefaultUnit = default(WavenumberUnit).SiUnit;
        private bool isUpdatingScalarValue;

        static WavenumberRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WavenumberRow), new FrameworkPropertyMetadata(typeof(WavenumberRow)));
            SuffixProperty.OverrideMetadata(
                typeof(WavenumberRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(UnitRow.DefaultSymbolFormat, DefaultUnit),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }

        public Wavenumber? Value
        {
            get { return (Wavenumber?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public Wavenumber? MinValue
        {
            get { return (Wavenumber?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public Wavenumber? MaxValue
        {
            get { return (Wavenumber?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public WavenumberUnit Unit
        {
            get { return (WavenumberUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

        string IQuantityFormatter.Format(IQuantity quantity)
        {
            if (quantity == null)
            {
                return string.Empty;
            }

            if (!(quantity is Wavenumber))
            {
                return "wrong type";
            }

            var qty = (Wavenumber)quantity;
            var culture = NumericBox.GetCulture(this);
            return qty.ToString(this.Unit, this.SymbolFormat, culture);
        }

        protected static string CreateSuffix(SymbolFormat format, WavenumberUnit unit)
        {
            return default(Wavenumber).ToString(unit, format).Trim('0');
        }
		
        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WavenumberRow)d).OnMinValueChanged((Wavenumber?)e.OldValue, (Wavenumber?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WavenumberRow)d).OnMaxValueChanged((Wavenumber?)e.OldValue, (Wavenumber?)e.NewValue);
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (WavenumberRow)d;
            var oldSuffix = CreateSuffix(row.SymbolFormat, (WavenumberUnit)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = CreateSuffix(row.SymbolFormat, (WavenumberUnit)e.NewValue);
            }

            row.SetScalarValue(ScalarValueProperty, row.Value);
            row.SetScalarValue(ScalarMinValueProperty, row.MinValue);
            row.SetScalarValue(ScalarMaxValueProperty, row.MaxValue);
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            this.SetScalarValue(ScalarValueProperty, (Wavenumber?)newValue);
            base.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnMinValueChanged(Wavenumber? oldValue, Wavenumber? newValue)
        {
            this.SetScalarValue(ScalarMinValueProperty, newValue);
        }

        protected virtual void OnMaxValueChanged(Wavenumber? oldValue, Wavenumber? newValue)
        {
            this.SetScalarValue(ScalarMaxValueProperty, newValue);
        }

        protected override void OnScalarValueChanged(double? newValue)
        {
            this.SetQuantityValue(ValueProperty, newValue);
        }

        protected override void OnScalarMinValueChanged(double? newValue)
        {
            this.SetQuantityValue(MinValueProperty, newValue);
        }

        protected override void OnScalarMaxValueChanged(double? newValue)
        {
            this.SetQuantityValue(MaxValueProperty, newValue);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }

        protected void SetScalarValue(DependencyProperty property, Wavenumber? quantity)
        {
            // we set this flag to prevent from setting scalar value changing quantity values.
            this.isUpdatingScalarValue = true;
            var value = quantity != null
                ? this.Unit.GetScalarValue(quantity.Value)
                : (double?)null;
            this.SetCurrentValue(property, value);
            this.isUpdatingScalarValue = false;
        }

        protected virtual void SetQuantityValue(DependencyProperty property, double? value)
        {
            if (this.isUpdatingScalarValue)
            {
                return;
            }

            var qty = value != null
                ? this.Unit.CreateQuantity(value.Value)
                : (Wavenumber?)null;
            this.SetCurrentValue(property, qty);
        }

        protected override string CreateSuffix(SymbolFormat format)
        {
            return CreateSuffix(format, this.Unit);
        }
    }
}
