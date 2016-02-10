namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    using Gu.Wpf.ValidationScope;

    public class CheckBoxSettingControl : BoolSettingControl
    {
        static CheckBoxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBoxSettingControl), new FrameworkPropertyMetadata(typeof(CheckBoxSettingControl)));
            ValidationInputTypesProperty.OverrideMetadataWithDefaultValue(typeof(SettingControlBase), typeof(CheckBoxSettingControl), new InputTypeCollection { typeof(SettingControlBase), typeof(CheckBox) });
        }
    }
}