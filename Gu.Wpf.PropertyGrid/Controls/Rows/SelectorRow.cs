namespace Gu.Wpf.PropertyGrid
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// A property grid row for selecting values from a list.
    /// </summary>
    public class SelectorRow : GenericRow<object>
    {
        public static readonly DependencyProperty ItemsSourceProperty = ItemsControl.ItemsSourceProperty.AddOwner(
            typeof(SelectorRow),
            new FrameworkPropertyMetadata(default(IEnumerable)));

        static SelectorRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorRow), new FrameworkPropertyMetadata(typeof(SelectorRow)));
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)this.GetValue(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, value);
        }
    }
}