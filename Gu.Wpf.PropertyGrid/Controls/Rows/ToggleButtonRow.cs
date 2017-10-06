namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    /// <summary>
    /// A property grid row for boolean values that renders toggle buttons.
    /// </summary>
    public class ToggleButtonRow : BoolRow
    {
        static ToggleButtonRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonRow), new FrameworkPropertyMetadata(typeof(ToggleButtonRow)));
        }
    }
}