namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class Rows : ItemsControl
    {
        /// <summary>Identifies the IsReadOnly dependency property.</summary>
        public static readonly DependencyProperty IsReadOnlyProperty = PropertyGrid.IsReadOnlyProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.Inherits));

        static Rows()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(typeof(Rows)));
            FocusableProperty.OverrideMetadata(typeof(Rows), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the row is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get => (bool)this.GetValue(IsReadOnlyProperty);
            set => this.SetValue(IsReadOnlyProperty, value);
        }

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // nop
        }
    }
}
