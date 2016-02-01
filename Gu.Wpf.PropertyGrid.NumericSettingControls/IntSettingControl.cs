namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class IntSettingControl : NumericSettingControl<int>
    {
        static IntSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntSettingControl), new FrameworkPropertyMetadata(typeof(IntSettingControl)));
        }
    }
}