namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using Gu.Wpf.NumericInput;
    using Gu.Wpf.NumericInput.Select;

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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var valueBinding = BindingOperations.GetBindingExpression(this, ValueProperty);
            if (valueBinding?.ParentBinding.UpdateSourceTrigger == UpdateSourceTrigger.PropertyChanged)
            {
                foreach (var dependencyObject in this.RecursiveChildren())
                {
                    BindingExpression bindingExpression = null;
                    switch (dependencyObject)
                    {
                        case DecimalBox decimalBox:
                            bindingExpression = decimalBox.GetBindingExpression(DecimalBox.ValueProperty);
                            break;
                        case DoubleBox doubleBox:
                            bindingExpression = doubleBox.GetBindingExpression(DoubleBox.ValueProperty);
                            break;
                        case FloatBox floatBox:
                            bindingExpression = floatBox.GetBindingExpression(DecimalBox.ValueProperty);
                            break;
                        case IntBox intBox:
                            bindingExpression = intBox.GetBindingExpression(FloatBox.ValueProperty);
                            break;
                        case LongBox longBox:
                            bindingExpression = longBox.GetBindingExpression(LongBox.ValueProperty);
                            break;
                        case ShortBox shortBox:
                            bindingExpression = shortBox.GetBindingExpression(ShortBox.ValueProperty);
                            break;
                        case System.Windows.Controls.TextBox textBox:
                            bindingExpression = textBox.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty);
                            break;
                    }

                    if (bindingExpression != null && bindingExpression.ParentBinding.UpdateSourceTrigger != UpdateSourceTrigger.PropertyChanged)
                    {
                        dependencyObject.SetCurrentValue(ForegroundProperty, Brushes.Red);
                        dependencyObject.SetCurrentValue(
                            System.Windows.Controls.TextBox.TextProperty,
                            "Binding of value with UpdateSourceTrigger.PropertyChanged does not match the binding for the value by the current controltemplate");
                    }
                }
            }
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
