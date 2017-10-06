namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using Gu.Units;
    using Gu.Wpf.NumericInput;

    /// <summary>
    /// Base class for unit row.
    /// </summary>
    public abstract class UnitRow : Row
    {
        /// <summary>Identifies the <see cref="ScalarValue"/> dependency property.</summary>
        public static readonly DependencyProperty ScalarValueProperty = DependencyProperty.Register(
            nameof(ScalarValue),
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarValueChanged));

        /// <summary>Identifies the <see cref="ScalarMinValue"/> dependency property.</summary>
        public static readonly DependencyProperty ScalarMinValueProperty = DependencyProperty.Register(
            nameof(ScalarMinValue),
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarMinValueChanged));

        /// <summary>Identifies the <see cref="ScalarMaxValue"/> dependency property.</summary>
        public static readonly DependencyProperty ScalarMaxValueProperty = DependencyProperty.Register(
            nameof(ScalarMaxValue),
            typeof(double?),
            typeof(UnitRow),
            new PropertyMetadata(default(double?), OnScalarMaxValueChanged));

        /// <summary> The default symbol format. </summary>
        public static readonly SymbolFormat DefaultSymbolFormat = SymbolFormat.Default;

        /// <summary>Identifies the <see cref="SymbolFormat"/> dependency property.</summary>
        public static readonly DependencyProperty SymbolFormatProperty = DependencyProperty.RegisterAttached(
            nameof(SymbolFormat),
            typeof(SymbolFormat),
            typeof(UnitRow),
            new FrameworkPropertyMetadata(
                DefaultSymbolFormat,
                FrameworkPropertyMetadataOptions.Inherits,
                OnSymbolFormatChanged));

        /// <summary>Identifies the <see cref="DecimalDigits"/> dependency property.</summary>
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(UnitRow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the <see cref="CanValueBeNull"/> dependency property.</summary>
        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(UnitRow),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static UnitRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitRow), new FrameworkPropertyMetadata(typeof(UnitRow)));
        }

        /// <summary>
        /// Gets or sets the Value property as a double.
        /// </summary>
        public double? ScalarValue
        {
            get => (double?)this.GetValue(ScalarValueProperty);
            set => this.SetValue(ScalarValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the MinValue property as a double.
        /// </summary>
        public double? ScalarMinValue
        {
            get => (double?)this.GetValue(ScalarMinValueProperty);
            set => this.SetValue(ScalarMinValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the MaxValue property as a double.
        /// </summary>
        public double? ScalarMaxValue
        {
            get => (double?)this.GetValue(ScalarMaxValueProperty);
            set => this.SetValue(ScalarMaxValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="SymbolFormat"/> to use when formatting the suffix.
        /// </summary>
        public SymbolFormat SymbolFormat
        {
            get => (SymbolFormat)this.GetValue(SymbolFormatProperty);
            set => this.SetValue(SymbolFormatProperty, value);
        }

        /// <summary>
        /// Gets or sets the number of decimal digits:
        /// DecimalDigits="3" sets StringFormat to F3
        /// DecimalDigits="-3" sets StringFormat to 0.###
        /// Default is null.
        /// </summary>
        public int? DecimalDigits
        {
            get => (int?)this.GetValue(DecimalDigitsProperty);
            set => this.SetValue(DecimalDigitsProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether null is an allowed value for the Value property
        /// </summary>
        public bool CanValueBeNull
        {
            get => (bool)this.GetValue(CanValueBeNullProperty);
            set => this.SetValue(CanValueBeNullProperty, value);
        }

        /// <summary>
        /// DependencyProperty getter for <see cref="SymbolFormat" /> property.
        /// </summary>
        /// <param name="element">The element from which to read the attached property.</param>
        /// <returns>The current value of the property.</returns>
        public static SymbolFormat GetSymbolFormat(UIElement element)
        {
            return (SymbolFormat)element.GetValue(SymbolFormatProperty);
        }

        /// <summary>
        /// DependencyProperty setter for <see cref="SymbolFormat" /> property.
        /// </summary>
        /// <param name="element">The element to which to write the attached property.</param>
        /// <param name="value">The property value to set</param>
        public static void SetSymbolFormat(UIElement element, SymbolFormat value)
        {
            element.SetValue(SymbolFormatProperty, value);
        }

        /// <summary>
        /// Create a suffix sting for the current Unit
        /// </summary>
        /// <param name="symbolFormat">The symbol format to use.</param>
        /// <returns>The string representation of the unit including leading whitespace if any.</returns>
        protected abstract string CreateSuffix(SymbolFormat symbolFormat);

        /// <summary>
        /// Called when the <see cref="ScalarValue"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void OnScalarValueChanged(double? newValue);

        /// <summary>
        /// Called when the <see cref="ScalarMinValue"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void OnScalarMinValueChanged(double? newValue);

        /// <summary>
        /// Called when the <see cref="ScalarMaxValue"/> changes.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void OnScalarMaxValueChanged(double? newValue);

        private static void OnScalarValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarValueChanged((double?)e.NewValue);
        }

        private static void OnScalarMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarMinValueChanged((double?)e.NewValue);
        }

        private static void OnScalarMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UnitRow)d).OnScalarMaxValueChanged((double?)e.NewValue);
        }

        private static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
    }
}