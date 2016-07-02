namespace Gu.Wpf.PropertyGrid
{
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Xaml;

    public abstract class ControlTemplateSelector<T> : INotifyPropertyChanged
        where T : Control
    {
        private ControlTemplate current;

        public event PropertyChangedEventHandler PropertyChanged;

        public ControlTemplate Current
        {
            get
            {
                return this.current;
            }

            protected set
            {
                if (value == this.current)
                {
                    return;
                }

                this.current = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Current)));
            }
        }

        public virtual void UpdateCurrentTemplate(T container) => this.Current = this.SelectTemplate(container);

        protected abstract ControlTemplate SelectTemplate(T container);

        protected static void AssertIsValidTemplate(ControlTemplate template)
        {
            if (!IsValidTemplate(template))
            {
                throw new XamlException($"Not a valid template for {typeof(T).Name}");
            }
        }

        protected static bool IsValidTemplate(ControlTemplate template)
        {
            var targetType = template?.TargetType;
            if (targetType == null)
            {
                return false;
            }

            return typeof(T).IsAssignableFrom(targetType);
        }
    }
}
