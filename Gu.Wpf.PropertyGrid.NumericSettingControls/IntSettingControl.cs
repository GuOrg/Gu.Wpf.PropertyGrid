namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using Gu.Wpf.NumericInput;

    public class IntSettingControl : NumericSettingControl<int>
    {
        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(IntSettingControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static IntSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntSettingControl), new FrameworkPropertyMetadata(typeof(IntSettingControl)));
        }

        public bool CanValueBeNull
        {
            get { return (bool)this.GetValue(CanValueBeNullProperty); }
            set { this.SetValue(CanValueBeNullProperty, value); }
        }
    }
}