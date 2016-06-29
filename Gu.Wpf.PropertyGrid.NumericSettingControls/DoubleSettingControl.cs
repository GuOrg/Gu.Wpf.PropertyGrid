namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    using Gu.Wpf.NumericInput;

    public class DoubleSettingControl : NumericSettingControl<double>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(DoubleSettingControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(DoubleSettingControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static DoubleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleSettingControl), new FrameworkPropertyMetadata(typeof(DoubleSettingControl)));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(DoubleSettingControl), UpdateSourceTrigger.LostFocus);
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
    }
}
