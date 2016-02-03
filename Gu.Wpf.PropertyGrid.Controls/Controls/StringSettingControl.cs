namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    public class StringSettingControl : SettingControlBase<string>
    {
        static StringSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StringSettingControl), new FrameworkPropertyMetadata(typeof(StringSettingControl)));
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(StringSettingControl), UpdateSourceTrigger.LostFocus);
        }
    }
}