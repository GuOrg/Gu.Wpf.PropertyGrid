namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
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

        private readonly List<DependencyObject> templateChildren = new List<DependencyObject>();

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

        protected virtual void OnTemplateChildError(object sender, ValidationErrorEventArgs args)
        {
            var errors2 = Validation.GetErrors((DependencyObject)args.Source);
            var valueBinding = BindingOperations.GetBindingExpression(this, ValueProperty);
            Validation.ClearInvalid(valueBinding);
            foreach (var validationError in errors2)
            {
                Validation.MarkInvalid(valueBinding, validationError);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var valueBinding = BindingOperations.GetBindingExpression(this, ValueProperty);
            if (valueBinding != null && this.templateChildren.Any())
            {
                Validation.ClearInvalid(valueBinding);
                foreach (var dependencyObject in this.templateChildren)
                {
                    Validation.RemoveErrorHandler(dependencyObject, this.OnTemplateChildError);
                }
            }

            if (valueBinding?.ParentBinding != null)
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
                            bindingExpression = floatBox.GetBindingExpression(FloatBox.ValueProperty);
                            break;
                        case IntBox intBox:
                            bindingExpression = intBox.GetBindingExpression(IntBox.ValueProperty);
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

                    if (bindingExpression != null)
                    {
                        if (valueBinding.ParentBinding.UpdateSourceTrigger == UpdateSourceTrigger.PropertyChanged && bindingExpression.ParentBinding.UpdateSourceTrigger != UpdateSourceTrigger.PropertyChanged)
                        {
                            dependencyObject.SetCurrentValue(ForegroundProperty, Brushes.Red);
                            dependencyObject.SetCurrentValue(
                                System.Windows.Controls.TextBox.TextProperty,
                                "Binding of value with UpdateSourceTrigger.PropertyChanged does not match the binding for the value by the current controltemplate");
                        }

                        Validation.AddErrorHandler(dependencyObject, this.OnTemplateChildError);
                        this.templateChildren.Add(dependencyObject);
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
