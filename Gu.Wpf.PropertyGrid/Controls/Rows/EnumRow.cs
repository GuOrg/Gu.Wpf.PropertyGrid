namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    public class EnumRow : GenericRow<object>
    {
#pragma warning disable SA1202 // Elements must be ordered by access

        public static readonly DependencyProperty EnumTypeProperty = DependencyProperty.Register(
            "EnumType",
            typeof(Type),
            typeof(EnumRow),
            new PropertyMetadata(default(Type), OnEnumTypeChanged),
            OnEnumTypeValidate);

        private static readonly DependencyPropertyKey EnumValuesPropertyKey = DependencyProperty.RegisterReadOnly(
            "EnumValues",
            typeof(IReadOnlyList<IFormattable>),
            typeof(EnumRow),
            new PropertyMetadata(default(IReadOnlyList<IFormattable>)));

        public static readonly DependencyProperty EnumValuesProperty = EnumValuesPropertyKey.DependencyProperty;

#pragma warning restore SA1202 // Elements must be ordered by access

        static EnumRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumRow), new FrameworkPropertyMetadata(typeof(EnumRow)));
        }

        public Type EnumType
        {
            get { return (Type)this.GetValue(EnumTypeProperty); }
            set { this.SetValue(EnumTypeProperty, value); }
        }

        public IReadOnlyList<IFormattable> EnumValues
        {
            get { return (IReadOnlyList<IFormattable>)this.GetValue(EnumValuesProperty); }
            protected set { this.SetValue(EnumValuesPropertyKey, value); }
        }

        protected override void OnValueChanged(object oldValue, object newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            if (this.EnumType == null && newValue != null)
            {
                this.SetCurrentValue(EnumTypeProperty, newValue.GetType());
            }
        }

        private static void OnEnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                d.SetValue(EnumValuesPropertyKey, null);
            }
            else
            {
                var values = Enum.GetValues((Type)e.NewValue)
                    .Cast<IFormattable>()
                    .ToArray();
                d.SetValue(EnumValuesPropertyKey, values);
            }
        }

        private static bool OnEnumTypeValidate(object value)
        {
            return ((Type)value)?.IsEnum != false;
        }
    }
}