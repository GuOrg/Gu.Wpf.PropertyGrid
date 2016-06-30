namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    public abstract class Row<T> : Row
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(T),
            typeof(Row<T>),
            new FrameworkPropertyMetadata(
                default(T),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnValueChanged,
                null,
                true,
                UpdateSourceTrigger.PropertyChanged));

        public T Value
        {
            get { return (T)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        protected override DependencyProperty ValueDependencyProperty => ValueProperty;

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