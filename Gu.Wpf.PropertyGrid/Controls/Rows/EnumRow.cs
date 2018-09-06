namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// A property grid row for enum values that renders combo boxes.
    /// </summary>
    public class EnumRow : GenericRow<object>
    {
#pragma warning disable SA1202 // Elements must be ordered by access

        /// <summary>Identifies the <see cref="EnumType"/> dependency property.</summary>
        public static readonly DependencyProperty EnumTypeProperty = DependencyProperty.Register(
            nameof(EnumType),
            typeof(Type),
            typeof(EnumRow),
            new PropertyMetadata(default(Type), OnEnumTypeChanged),
            value => ((Type)value)?.IsEnum != false);

        private static readonly DependencyPropertyKey EnumValuesPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(EnumValues),
            typeof(IReadOnlyList<IFormattable>),
            typeof(EnumRow),
            new PropertyMetadata(default(IReadOnlyList<IFormattable>)));

        /// <summary>Identifies the <see cref="EnumValues"/> dependency property.</summary>
        public static readonly DependencyProperty EnumValuesProperty = EnumValuesPropertyKey.DependencyProperty;

#pragma warning restore SA1202 // Elements must be ordered by access

        static EnumRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumRow), new FrameworkPropertyMetadata(typeof(EnumRow)));
        }

        public Type EnumType
        {
            get => (Type)this.GetValue(EnumTypeProperty);
            set => this.SetValue(EnumTypeProperty, value);
        }

        public IReadOnlyList<IFormattable> EnumValues
        {
            get => (IReadOnlyList<IFormattable>)this.GetValue(EnumValuesProperty);
            protected set => this.SetValue(EnumValuesPropertyKey, value);
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
    }
}
