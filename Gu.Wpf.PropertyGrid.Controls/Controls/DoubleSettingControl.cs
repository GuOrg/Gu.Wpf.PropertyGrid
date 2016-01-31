using System.Windows;

namespace Gu.Wpf.PropertyGrid
{
    public class DoubleSettingControl : NumericSettingControl<double>
    {
        static DoubleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleSettingControl), new FrameworkPropertyMetadata(typeof(DoubleSettingControl)));
        }
    }
}
