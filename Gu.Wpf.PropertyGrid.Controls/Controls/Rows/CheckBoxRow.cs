namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class CheckBoxRow : BoolRow
    {
        static CheckBoxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBoxRow), new FrameworkPropertyMetadata(typeof(CheckBoxRow)));
        }
    }
}