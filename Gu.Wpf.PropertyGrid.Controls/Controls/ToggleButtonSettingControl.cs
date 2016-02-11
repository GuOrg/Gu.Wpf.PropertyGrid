namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class ToggleButtonSettingControl : BoolSettingControl
    {
        static ToggleButtonSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonSettingControl), new FrameworkPropertyMetadata(typeof(ToggleButtonSettingControl)));
        }
    }
}