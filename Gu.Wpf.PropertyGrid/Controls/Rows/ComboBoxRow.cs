namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    /// <summary>
    /// A property grid row for lists values that renders combo boxes.
    /// </summary>
    public class ComboBoxRow : SelectorRow
    {
        static ComboBoxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxRow), new FrameworkPropertyMetadata(typeof(ComboBoxRow)));
        }
    }
}