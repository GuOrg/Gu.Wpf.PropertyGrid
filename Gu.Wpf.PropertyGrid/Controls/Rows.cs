namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class Rows : ItemsControl
    {
        static Rows()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(typeof(Rows)));
            FocusableProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // nop
        }
    }
}
