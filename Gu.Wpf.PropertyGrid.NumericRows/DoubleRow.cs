namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System.Windows;
    using System.Windows.Data;
    using Gu.Wpf.NumericInput;

    public class DoubleRow : NumericRow<double>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(DoubleRow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(DoubleRow),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static DoubleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleRow), new FrameworkPropertyMetadata(typeof(DoubleRow)));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(DoubleRow), UpdateSourceTrigger.LostFocus);
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
