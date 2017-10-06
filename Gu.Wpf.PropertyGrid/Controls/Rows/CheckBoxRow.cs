namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    /// <summary>
    /// A property grid row for boolean values that renders check boxes.
    /// </summary>
    public class CheckBoxRow : BoolRow
    {
        static CheckBoxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBoxRow), new FrameworkPropertyMetadata(typeof(CheckBoxRow)));
        }
    }
}