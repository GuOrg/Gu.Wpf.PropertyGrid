namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    public abstract class SettingControlBase<T> : SettingControlBase
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(T),
            typeof(SettingControlBase<T>),
            new FrameworkPropertyMetadata
            {
                PropertyChangedCallback = OnValueChanged,
                DefaultValue = default(T),
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        public T Value
        {
            get { return (T)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;
    }
}