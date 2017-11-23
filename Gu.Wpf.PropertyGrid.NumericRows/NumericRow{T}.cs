namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using Gu.Wpf.NumericInput;

    public abstract class NumericRow<T> : GenericRow<T?>, INumericFormatter
        where T : struct, IComparable<T>
    {
        /// <summary>Identifies the <see cref="MinValue"/> dependency property.</summary>
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(T?),
            typeof(NumericRow<T>),
            new PropertyMetadata(null, OnMinValueChanged));

        /// <summary>Identifies the <see cref="MaxValue"/> dependency property.</summary>
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(T?),
            typeof(NumericRow<T>),
            new PropertyMetadata(null, OnMaxValueChanged));

        static NumericRow()
        {
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(NumericRow<T>), UpdateSourceTrigger.LostFocus);
        }

        public T? MinValue
        {
            get => (T?)this.GetValue(MinValueProperty);
            set => this.SetValue(MinValueProperty, value);
        }

        public T? MaxValue
        {
            get => (T?)this.GetValue(MaxValueProperty);
            set => this.SetValue(MaxValueProperty, value);
        }

        string INumericFormatter.Format(IFormattable value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (!(value is T))
            {
                return "wrong type";
            }

            var culture = NumericBox.GetCulture(this);
            return value.ToString(string.Empty, culture);
        }

        protected static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericRow<T>)d).OnMinValueChanged((T?)e.OldValue, (T?)e.NewValue);
        }

        protected static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericRow<T>)d).OnMaxValueChanged((T?)e.OldValue, (T?)e.NewValue);
        }

        protected virtual void OnMinValueChanged(T? oldValue, T? newValue)
        {
        }

        protected virtual void OnMaxValueChanged(T? oldValue, T? newValue)
        {
        }
    }
}
