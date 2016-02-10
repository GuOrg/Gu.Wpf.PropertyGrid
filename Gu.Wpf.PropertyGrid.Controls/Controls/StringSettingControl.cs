namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Gu.Wpf.ValidationScope;

    public class StringSettingControl : SettingControlBase<string>
    {
        static StringSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StringSettingControl), new FrameworkPropertyMetadata(typeof(StringSettingControl)));
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(StringSettingControl), UpdateSourceTrigger.LostFocus);
            ValidationInputTypesProperty.OverrideMetadataWithDefaultValue(typeof(SettingControlBase), typeof(StringSettingControl), new InputTypeCollection { typeof(SettingControlBase), typeof(TextBox) });
        }
    }
}