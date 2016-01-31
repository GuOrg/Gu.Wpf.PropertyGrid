using System.Windows;

namespace Gu.Wpf.PropertyGrid
{
    public class StringSettingControl : SettingControlBase<string>
    {
        static StringSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StringSettingControl), new FrameworkPropertyMetadata(typeof(StringSettingControl)));
        }
    }
}