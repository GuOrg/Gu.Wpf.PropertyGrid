namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    using Gu.Wpf.NumericInput;
    using Gu.Wpf.ValidationScope;

    public class IntSettingControl : NumericSettingControl<int>
    {
        public static readonly DependencyProperty CanValueBeNullProperty = NumericBox.CanValueBeNullProperty.AddOwner(
            typeof(IntSettingControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        static IntSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntSettingControl), new FrameworkPropertyMetadata(typeof(IntSettingControl)));
            ValidationInputTypesProperty.OverrideMetadataWithDefaultValue(typeof(SettingControlBase), typeof(IntSettingControl), new InputTypeCollection { typeof(SettingControlBase), typeof(IntBox), typeof(TextBox) });
        }

        public bool CanValueBeNull
        {
            get { return (bool)this.GetValue(CanValueBeNullProperty); }
            set { this.SetValue(CanValueBeNullProperty, value); }
        }
    }
}