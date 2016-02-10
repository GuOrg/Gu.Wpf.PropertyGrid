namespace Gu.Wpf.PropertyGrid
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    using Gu.Wpf.ValidationScope;

    public class SelectorSettingControl : SettingControlBase<object>
    {
        public static readonly DependencyProperty ItemsSourceProperty = ItemsControl.ItemsSourceProperty.AddOwner(
            typeof(SelectorSettingControl), new FrameworkPropertyMetadata(default(IEnumerable)));

        static SelectorSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorSettingControl), new FrameworkPropertyMetadata(typeof(SelectorSettingControl)));
            ValidationInputTypesProperty.OverrideMetadataWithDefaultValue(typeof(SettingControlBase), typeof(SelectorSettingControl), new InputTypeCollection { typeof(SettingControlBase), typeof(Selector) });
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable) this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }
    }
}