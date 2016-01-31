using System.Windows;

namespace Gu.PropertyGrid
{
    public class BoolSettingControl : SettingControlBase<bool>
    {
        static BoolSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolSettingControl), new FrameworkPropertyMetadata(typeof(BoolSettingControl)));
        }
    }
}