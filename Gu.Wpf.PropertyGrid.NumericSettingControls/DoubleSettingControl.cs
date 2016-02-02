namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using Gu.Wpf.NumericInput;

    public class DoubleSettingControl : NumericSettingControl<double>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof (DoubleSettingControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        static DoubleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleSettingControl), new FrameworkPropertyMetadata(typeof(DoubleSettingControl)));
        }

        public int? DecimalDigits
        {
            get { return (int?)this.GetValue(DecimalDigitsProperty); }
            set { this.SetValue(DecimalDigitsProperty, value); }
        }
    }
}
