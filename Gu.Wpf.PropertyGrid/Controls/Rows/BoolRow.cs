namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public class BoolRow : Row<bool>
    {
        static BoolRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolRow), new FrameworkPropertyMetadata(typeof(BoolRow)));
        }
    }
}