namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class ComboBoxRow : SelectorRow
    {
        static ComboBoxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxRow), new FrameworkPropertyMetadata(typeof(ComboBoxRow)));
        }
    }
}