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
        /// <summary>
        /// The name of the template child used to edit the Value property
        /// </summary>
        public const string ValueBoxName = "PART_Value";

        /// <summary>
        /// Gets the dependency property for the value of this row.
        /// </summary>
        protected DependencyProperty ValueDependencyProperty { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Row"/> class.
        /// </summary>
        /// <param name="valueDependencyProperty">The dependency property containing the value.</param>
        protected Row(DependencyProperty valueDependencyProperty)
        {
            this.ValueDependencyProperty = valueDependencyProperty;
        }

        /// <summary>
        /// Called when the Value property changes value.
        /// </summary>
        /// <param name="o">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/></param>
        protected static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var row = (Row)o;
            row.OnValueChanged(e.OldValue, e.NewValue);
        }

        /// <inheritdoc/>
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return new RowAutomationPeer(this);
        }

        /// <summary>
        /// Called when the Value property changes value.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnValueChanged(object oldValue, object newValue)
        {
            this.UpdateIsDirty();
        }

        protected virtual void OnOldValueChanged(object oldValue, object newValue)
        {
        }

        /// <inheritdoc />
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

        /// <summary>
        /// Update the value of the <see cref="Row.IsDirty"/> property
        /// </summary>
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

                _ = BindingOperations.SetBinding(this, OldValueProperty, oldValueBinding);
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
                _ = d.Dispatcher.BeginInvoke(
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
