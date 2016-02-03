namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    public abstract class NumericSettingControl<T> : SettingControlBase<T?>
        where T : struct, IComparable<T>
    {
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(T?),
            typeof(NumericSettingControl<T>),
            new PropertyMetadata(null, OnMinValueChanged));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(T?),
            typeof(NumericSettingControl<T>),
            new PropertyMetadata(null, OnMaxValueChanged));

        static NumericSettingControl()
        {
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(NumericSettingControl<T>), UpdateSourceTrigger.LostFocus);
        }

        public T? MinValue
        {
            get { return (T?)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        public T? MaxValue
        {
            get { return (T?)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        protected virtual void OnMinValueChanged(T? oldValue, T? newValue)
        {
        }

        protected virtual void OnMaxValueChanged(T? oldValue, T? newValue)
        {
        }

        private static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericSettingControl<T>)d).OnMinValueChanged((T?)e.OldValue, (T?)e.NewValue);
        }

        private static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericSettingControl<T>)d).OnMaxValueChanged((T?)e.OldValue, (T?)e.NewValue);

        }
    }
}
