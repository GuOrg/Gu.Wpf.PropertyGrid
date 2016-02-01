namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class DoubleSettingControl : NumericSettingControl<double>
    {
        static DoubleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleSettingControl), new FrameworkPropertyMetadata(typeof(DoubleSettingControl)));
        }
    }
}
