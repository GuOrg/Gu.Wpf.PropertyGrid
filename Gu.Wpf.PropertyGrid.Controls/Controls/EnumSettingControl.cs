namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    public class EnumSettingControl : SettingControlBase<ValueType>
    {
        public static readonly DependencyProperty EnumTypeProperty = DependencyProperty.Register(
            "EnumType",
            typeof(Type),
            typeof(EnumSettingControl),
            new PropertyMetadata(default(Type), OnEnumTypeChanged));

        private static readonly DependencyPropertyKey EnumValuesPropertyKey = DependencyProperty.RegisterReadOnly(
            "EnumValues",
            typeof(IReadOnlyList<ValueType>),
            typeof(EnumSettingControl),
            new PropertyMetadata(default(IReadOnlyList<ValueType>)));

        public static readonly DependencyProperty EnumValuesProperty = EnumValuesPropertyKey.DependencyProperty;

        static EnumSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumSettingControl), new FrameworkPropertyMetadata(typeof(EnumSettingControl)));
        }

        public Type EnumType
        {
            get { return (Type)this.GetValue(EnumTypeProperty); }
            set { this.SetValue(EnumTypeProperty, value); }
        }

        public IReadOnlyList<ValueType> EnumValues
        {
            get { return (IReadOnlyList<ValueType>) this.GetValue(EnumValuesProperty); }
            protected set { this.SetValue(EnumValuesPropertyKey, value); }
        }

        private static void OnEnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var values = Enum.GetValues((Type)e.NewValue);
            d.SetValue(EnumValuesPropertyKey, values);
        }
    }
}