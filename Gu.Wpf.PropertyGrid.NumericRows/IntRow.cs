namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System.Windows;
    using System.Windows.Data;
    using Gu.Wpf.NumericInput;

    public class IntRow : NumericRow<int>
    {
        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(IntRow),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static IntRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntRow), new FrameworkPropertyMetadata(typeof(IntRow)));
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(IntRow), UpdateSourceTrigger.LostFocus);
        }

        public bool CanValueBeNull
        {
            get => (bool)this.GetValue(CanValueBeNullProperty);
            set => this.SetValue(CanValueBeNullProperty, value);
        }
    }
}
