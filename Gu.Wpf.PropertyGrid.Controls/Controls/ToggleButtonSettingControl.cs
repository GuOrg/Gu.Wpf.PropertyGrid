namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls.Primitives;

    using Gu.Wpf.ValidationScope;

    public class ToggleButtonSettingControl : BoolSettingControl
    {
        static ToggleButtonSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonSettingControl), new FrameworkPropertyMetadata(typeof(ToggleButtonSettingControl)));
            ValidationInputTypesProperty.OverrideMetadataWithDefaultValue(typeof(SettingControlBase), typeof(ToggleButtonSettingControl), new InputTypeCollection { typeof(SettingControlBase), typeof(ToggleButton) });
        }
    }
}