namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class Rows : ItemsControl
    {
        public static readonly DependencyProperty UsePropertyNameAsHeaderProperty =
            PropertyGrid.UsePropertyNameAsHeaderProperty.AddOwner(
                typeof(Rows),
                new FrameworkPropertyMetadata(
                    BooleanBoxes.False,
                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable));

        static Rows()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(typeof(Rows)));
            FocusableProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        public bool UsePropertyNameAsHeader
        {
            get => (bool)this.GetValue(UsePropertyNameAsHeaderProperty);
            set => this.SetValue(UsePropertyNameAsHeaderProperty, value);
        }

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // nop
        }
    }
}
