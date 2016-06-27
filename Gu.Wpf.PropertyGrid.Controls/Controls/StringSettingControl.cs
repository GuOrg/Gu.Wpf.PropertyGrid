namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class StringSettingControl : SettingControlBase<string>
    {
        static StringSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(StringSettingControl),
                new FrameworkPropertyMetadata(typeof(StringSettingControl)));
        }
    }
}