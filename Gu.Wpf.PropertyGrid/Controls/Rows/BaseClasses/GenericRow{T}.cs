namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    public abstract class GenericRow<T> : Row
    {
        /// <summary>Identifies the <see cref="Value"/> dependency property.</summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(T),
            typeof(GenericRow<T>),
            new FrameworkPropertyMetadata(
                defaultValue: default(T),
                flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                propertyChangedCallback: (d, e) => ((GenericRow<T>)d).OnValueChanged(e.OldValue, e.NewValue),
                coerceValueCallback: null,
                isAnimationProhibited: true,
                defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged));

        protected GenericRow()
            : base(ValueProperty)
        {
        }

        public T Value
        {
            get => (T)this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }

        protected override void UpdateIsDirty()
        {
            if (ReferenceEquals(this.OldValue, OldValueProperty.DefaultMetadata.DefaultValue))
            {
                this.IsDirty = null;
            }
            else
            {
                this.IsDirty = !Equals(this.OldValue, this.Value);
            }
        }
    }
}
