namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    /// <summary>
    /// A property grid row for boolean values.
    /// </summary>
    public class BoolRow : GenericRow<bool>
    {
        static BoolRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolRow), new FrameworkPropertyMetadata(typeof(BoolRow)));
        }
    }
}