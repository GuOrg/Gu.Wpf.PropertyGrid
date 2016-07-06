namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Threading;

    [TemplatePart(Name = ValueBoxName, Type = typeof(FrameworkElement))]
    public abstract partial class Row : Control
    {
        public const string ValueBoxName = "PART_Value";

        protected abstract DependencyProperty ValueDependencyProperty { get; }

        protected static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var sc = (Row)o;
            sc.OnValueChanged(e.OldValue, e.NewValue);
            sc.UpdateIsDirty();
        }

        /// <summary>Creates AutomationPeer (<see cref="UIElement.OnCreateAutomationPeer"/>)</summary>
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return new RowAutomationPeer(this);
        }

        protected virtual void OnValueChanged(object oldValue, object newValue)
        {
        }

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.UpdateTemplate();
            if (string.IsNullOrEmpty(this.Header) && this.UsePropertyNameAsHeader)
            {
                var binding = BindingOperations.GetBinding(this, this.ValueDependencyProperty);
                if (binding != null)
                {
                    var value = binding.Path?.Path.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                    this.SetCurrentValue(HeaderProperty, value);
                }
            }
        }

        protected virtual void UpdateTemplate()
        {
            this.ControlTemplateSelector?.UpdateCurrentTemplate(this);
        }

        protected abstract void UpdateIsDirty();

        protected virtual void OnOldDataContextChanged(object oldValue, object newValue)
        {
            var oldValueBinding = BindingOperations.GetBinding(this, OldValueProperty);
            if (oldValueBinding != null)
            {
                // We don't replace any bindings.
                return;
            }

            var valueBinding = BindingOperations.GetBinding(this, this.ValueDependencyProperty);
            if (valueBinding != null)
            {
                var path = $"{OldDataContextProperty.Name}.{valueBinding.Path.Path}";
                oldValueBinding = new Binding(path)
                {
                    Mode = BindingMode.OneWay,
                    Source = this,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };

                BindingOperations.SetBinding(this, OldValueProperty, oldValueBinding);
            }
        }

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (Row)d;
            if (row.IsLoaded)
            {
                row.OnOldDataContextChanged(e.OldValue, e.NewValue);
            }
            else
            {
                d.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => row.OnOldDataContextChanged(e.OldValue, e.NewValue)));
            }
        }

        private static void OnOldValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var sc = (Row)o;
            sc.UpdateIsDirty();
            sc.OnOldValueChanged(e.OldValue, e.NewValue);
        }
    }
}