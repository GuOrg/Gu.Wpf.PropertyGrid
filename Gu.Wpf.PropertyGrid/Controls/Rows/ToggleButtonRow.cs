namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class ToggleButtonRow : BoolRow
    {
        static ToggleButtonRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonRow), new FrameworkPropertyMetadata(typeof(ToggleButtonRow)));
        }
    }
}