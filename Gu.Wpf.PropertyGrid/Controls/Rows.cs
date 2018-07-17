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

        /// <summary>Identifies the OldDataContext dependency property.</summary>
        public static readonly DependencyProperty OldDataContextProperty = PropertyGrid.OldDataContextProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the OldValueStringFormat dependency property.</summary>
        public static readonly DependencyProperty OldValueStringFormatProperty = PropertyGrid.OldValueStringFormatProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                "Old value: {0}",
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

        /// <summary>
        /// Gets or sets the data context with old values.
        /// </summary>
        public object OldDataContext
        {
            get => (object)this.GetValue(OldDataContextProperty);
            set => this.SetValue(OldDataContextProperty, value);
        }

        /// <summary>
        /// Gets or sets the string format for the old value.
        /// </summary>
        public string OldValueStringFormat
        {
            get => (string)this.GetValue(OldValueStringFormatProperty);
            set => this.SetValue(OldValueStringFormatProperty, value);
        }
    }
}
