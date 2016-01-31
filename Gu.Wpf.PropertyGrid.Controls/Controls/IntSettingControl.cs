using System.Windows;

namespace Gu.Wpf.PropertyGrid
{
    public class IntSettingControl : NumericSettingControl<int>
    {
        static IntSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntSettingControl), new FrameworkPropertyMetadata(typeof(IntSettingControl)));
        }
    }
}