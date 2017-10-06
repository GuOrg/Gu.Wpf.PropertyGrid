namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using Gu.Units;
    using Gu.Wpf.NumericInput;

    public abstract class UnitRow : Row
    {
        public static readonly DependencyProperty ScalarValueProperty = DependencyProperty.Register(
            "ScalarValue",
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarValueChanged));

        public static readonly DependencyProperty ScalarMinValueProperty = DependencyProperty.Register(
            "ScalarMinValue",
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarMinValueChanged));

        public static readonly DependencyProperty ScalarMaxValueProperty = DependencyProperty.Register(
            "ScalarMaxValue",
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarMaxValueChanged));

        public static readonly SymbolFormat DefaultSymbolFormat = SymbolFormat.Default;

        public static readonly DependencyProperty SymbolFormatProperty = DependencyProperty.RegisterAttached(
            "SymbolFormat",
            typeof(SymbolFormat),
            typeof(UnitRow),
            new FrameworkPropertyMetadata(DefaultSymbolFormat, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(UnitRow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(UnitRow),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static UnitRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitRow), new FrameworkPropertyMetadata(typeof(UnitRow)));
        }

        public double? ScalarValue
        {
            get => (double?)this.GetValue(ScalarValueProperty);
            set => this.SetValue(ScalarValueProperty, value);
        }

        public double? ScalarMinValue
        {
            get => (double?)this.GetValue(ScalarMinValueProperty);
            set => this.SetValue(ScalarMinValueProperty, value);
        }

        public double? ScalarMaxValue
        {
            get => (double?)this.GetValue(ScalarMaxValueProperty);
            set => this.SetValue(ScalarMaxValueProperty, value);
        }

        public SymbolFormat SymbolFormat
        {
            get => (SymbolFormat)this.GetValue(SymbolFormatProperty);
            set => this.SetValue(SymbolFormatProperty, value);
        }

        public int? DecimalDigits
        {
            get => (int?)this.GetValue(DecimalDigitsProperty);
            set => this.SetValue(DecimalDigitsProperty, value);
        }

        public bool CanValueBeNull
        {
            get => (bool)this.GetValue(CanValueBeNullProperty);
            set => this.SetValue(CanValueBeNullProperty, value);
        }

        public static void SetSymbolFormat(UIElement element, SymbolFormat value)
        {
            element.SetValue(SymbolFormatProperty, value);
        }

        public static SymbolFormat GetSymbolFormat(UIElement element)
        {
            return (SymbolFormat)element.GetValue(SymbolFormatProperty);
        }

        protected static void OnScalarValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarValueChanged((double?)e.NewValue);
        }

        protected static void OnScalarMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarMinValueChanged((double?)e.NewValue);
        }

        protected static void OnScalarMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarMaxValueChanged((double?)e.NewValue);
        }

        protected static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (UnitRow)d;
            var oldSuffix = row.CreateSuffix((SymbolFormat)e.OldValue);
            if (Equals(row.Suffix, oldSuffix))
            {
                // the old suffix was set via code, ok to update it.
                // if user has set suffix to something localized we don't touch it.
                // user is responsible for updating then.
                row.SetCurrentValue(SuffixProperty, row.CreateSuffix((SymbolFormat)e.NewValue));
            }
        }

        protected abstract string CreateSuffix(SymbolFormat symbolFormat);

        protected abstract void OnScalarValueChanged(double? newValue);

        protected abstract void OnScalarMinValueChanged(double? newValue);

        protected abstract void OnScalarMaxValueChanged(double? newValue);
    }
}