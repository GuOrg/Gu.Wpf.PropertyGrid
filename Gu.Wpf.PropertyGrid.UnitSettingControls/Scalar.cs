namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static class Scalar
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(double?),
            typeof(Scalar),
            new PropertyMetadata(default(double?), OnValueChanged));

        public static void SetValue(SettingControlBase element, double? value)
        {
            element.SetValue(ValueProperty, value);
        }

        public static double? GetValue(SettingControlBase element)
        {
            return (double)element.GetValue(ValueProperty);
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scalarQuantities = (IScalarQuantities)d;
            scalarQuantities.SetValue((double?)e.NewValue);
        }
    }
}