namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public abstract class UnitRowGeneric : Row
    {
        public static readonly DependencyProperty ScalarValueProperty = DependencyProperty.Register(
            "ScalarValue",
            typeof(double?),
            typeof(UnitRowGeneric),
            new PropertyMetadata(default(double?), OnScalarValueChanged));

        public static readonly DependencyProperty ScalarMinValueProperty = DependencyProperty.Register(
            "ScalarMinValue",
            typeof(double?),
            typeof(UnitRowGeneric),
            new PropertyMetadata(default(double?), OnScalarMinValueChanged));

        public static readonly DependencyProperty ScalarMaxValueProperty = DependencyProperty.Register(
            "ScalarMaxValue",
            typeof(double?),
            typeof(UnitRowGeneric),
            new PropertyMetadata(default(double?), OnScalarMaxValueChanged));

        public static readonly DependencyProperty SymbolFormatProperty = UnitRow.SymbolFormatProperty.AddOwner(
            typeof(UnitRowGeneric),
            new FrameworkPropertyMetadata(
                UnitRow.DefaultSymbolFormat,
                FrameworkPropertyMetadataOptions.Inherits,
                OnSymbolFormatChanged));

        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(UnitRowGeneric),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(UnitRowGeneric),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

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

        public SymbolFormat SymbolFormat
        {
            get { return (SymbolFormat)this.GetValue(SymbolFormatProperty); }
            set { this.SetValue(SymbolFormatProperty, value); }
        }

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

        protected static void OnScalarValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRowGeneric)d).OnScalarValueChanged((double?)e.NewValue);
        }

        protected static void OnScalarMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRowGeneric)d).OnScalarMinValueChanged((double?)e.NewValue);
        }

        protected static void OnScalarMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRowGeneric)d).OnScalarMaxValueChanged((double?)e.NewValue);
        }

        protected static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (UnitRowGeneric)d;
            var oldSuffix = row.CreateSuffix((SymbolFormat)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.Suffix = row.CreateSuffix((SymbolFormat)e.NewValue);
            }
        }

        protected abstract string CreateSuffix(SymbolFormat symbolFormat);

        protected abstract void OnScalarValueChanged(double? newValue);

        protected abstract void OnScalarMinValueChanged(double? newValue);

        protected abstract void OnScalarMaxValueChanged(double? newValue);
    }
}