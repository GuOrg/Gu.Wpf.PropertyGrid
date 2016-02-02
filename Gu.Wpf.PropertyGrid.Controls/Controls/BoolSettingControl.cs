namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public abstract class BoolSettingControl : SettingControlBase<bool>
    {
        static BoolSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolSettingControl), new FrameworkPropertyMetadata(typeof(BoolSettingControl)));
        }
    }
}