namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    public abstract class GenericRow<T> : ValueRow
    {
        static GenericRow()
        {
            ValueProperty.OverrideMetadata(
                typeof(GenericRow<T>),
                new FrameworkPropertyMetadata(
                    defaultValue: default(T),
                    flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    propertyChangedCallback: (d, e) => ((GenericRow<T>)d).OnValueChanged(e.OldValue, e.NewValue),
                    coerceValueCallback: null,
                    isAnimationProhibited: true,
                    defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged));
        }

        public new T Value
        {
            get => (T)this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }
    }
}
