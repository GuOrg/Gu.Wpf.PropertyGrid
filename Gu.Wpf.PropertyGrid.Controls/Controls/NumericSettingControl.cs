using System;
using System.Windows;

namespace Gu.PropertyGrid
{
    public abstract class NumericSettingControl<T> : SettingControlBase<T>
        where T : struct, IComparable<T>
    {
        public static readonly DependencyProperty DecimalDigitsProperty = NumericBox.DecimalDigitsProperty.AddOwner(
            typeof(NumericSettingControl<T>),
            new FrameworkPropertyMetadata(3, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(T?),
            typeof(NumericSettingControl<T>),
            new PropertyMetadata(null));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(T?),
            typeof(NumericSettingControl<T>),
            new PropertyMetadata(null));

        public int DecimalDigits
        {
            get { return (int)this.GetValue(DecimalDigitsProperty); }
            set { this.SetValue(DecimalDigitsProperty, value); }
        }

        public T? MaxValue
        {
            get { return (T?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        public T? MinValue
        {
            get { return (T?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }
    }
}
