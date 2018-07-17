namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using Gu.Wpf.NumericInput;

    /// <summary>
    /// Base class for numeric property grid rows.
    /// </summary>
    /// <typeparam name="T">The type of the value to edit.</typeparam>
    public abstract class NumericRow<T> : GenericRow<T?>, INumericFormatter
        where T : struct, IComparable<T>
    {
        /// <summary>Identifies the <see cref="MinValue"/> dependency property.</summary>
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(T?),
            typeof(NumericRow<T>),
            new PropertyMetadata(null, (d, e) => ((NumericRow<T>)d).OnMinValueChanged((T?)e.OldValue, (T?)e.NewValue)));

        /// <summary>Identifies the <see cref="MaxValue"/> dependency property.</summary>
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(T?),
            typeof(NumericRow<T>),
            new PropertyMetadata(null, (d, e) => ((NumericRow<T>)d).OnMaxValueChanged((T?)e.OldValue, (T?)e.NewValue)));

        private readonly List<DependencyObject> templateChildren = new List<DependencyObject>();

        static NumericRow()
        {
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(NumericRow<T>), UpdateSourceTrigger.LostFocus);
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// The value is inclusive.
        /// If set to null no check for min is done.
        /// </summary>
        public T? MinValue
        {
            get => (T?)this.GetValue(MinValueProperty);
            set => this.SetValue(MinValueProperty, value);
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// The value is inclusive.
        /// If set to null no check for max is done.
        /// </summary>
        public T? MaxValue
        {
            get => (T?)this.GetValue(MaxValueProperty);
            set => this.SetValue(MaxValueProperty, value);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <summary>
        /// Called when the template child bound to the ValueProperty has changes in validation errors.
        /// </summary>
        /// <param name="sender">The template child.</param>
        /// <param name="args">The <see cref="ValidationErrorEventArgs"/></param>
        protected virtual void OnTemplateChildError(object sender, ValidationErrorEventArgs args)
        {
            if (BindingOperations.GetBindingExpression(this, ValueProperty) is BindingExpression valueBinding)
            {
                Validation.ClearInvalid(valueBinding);
                foreach (var validationError in Validation.GetErrors((DependencyObject)args.Source))
                {
                    Validation.MarkInvalid(valueBinding, validationError);
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="MinValueProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnMinValueChanged(T? oldValue, T? newValue)
        {
        }

        /// <summary>
        /// Called when the <see cref="MaxValueProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnMaxValueChanged(T? oldValue, T? newValue)
        {
        }
    }
}
