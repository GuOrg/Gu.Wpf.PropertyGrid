namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class CheckBoxSettingControl : BoolSettingControl
    {
        static CheckBoxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBoxSettingControl), new FrameworkPropertyMetadata(typeof(CheckBoxSettingControl)));
        }
    }
}