namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// A property grid row for string values.
    /// </summary>
    public class StringRow : GenericRow<string>
    {
        static StringRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StringRow), new FrameworkPropertyMetadata(typeof(StringRow)));
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(StringRow), UpdateSourceTrigger.LostFocus);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var valueBinding = BindingOperations.GetBindingExpression(this, ValueProperty);
            if (valueBinding?.ParentBinding.UpdateSourceTrigger == UpdateSourceTrigger.PropertyChanged)
            {
                foreach (var dependencyObject in this.RecursiveChildren())
                {
                    if (dependencyObject is TextBox textBox)
                    {
                        var bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);

                        if (bindingExpression != null && bindingExpression.ParentBinding.UpdateSourceTrigger !=
                            UpdateSourceTrigger.PropertyChanged)
                        {
                            dependencyObject.SetCurrentValue(ForegroundProperty, Brushes.Red);
                            dependencyObject.SetCurrentValue(
                                TextBox.TextProperty,
                                "Binding of value with UpdateSourceTrigger.PropertyChanged does not match the binding for the value by the current controltemplate");
                        }
                    }
                }
            }
        }
    }
}
