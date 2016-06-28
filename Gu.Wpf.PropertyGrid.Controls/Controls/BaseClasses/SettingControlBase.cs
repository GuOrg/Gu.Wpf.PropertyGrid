namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    [TemplatePart(Name = ValueBoxName, Type = typeof(FrameworkElement))]
    public abstract partial class SettingControlBase : Control
    {
        public const string ValueBoxName = "PART_ValueBox";

        protected abstract DependencyProperty ValueDependencyProperty { get; }

        protected static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var sc = (SettingControlBase)o;
            sc.OnValueChanged(e.OldValue, e.NewValue);
            sc.UpdateIsDirty();
        }

        /// <summary>Creates AutomationPeer (<see cref="UIElement.OnCreateAutomationPeer"/>)</summary>
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingControlAutomationPeer(this);
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

        protected abstract void UpdateIsDirty();

        private static void OnOldDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controlBase = (SettingControlBase)d;
            var oldValueBinding = BindingOperations.GetBinding(controlBase, OldValueProperty);
            if (oldValueBinding != null)
            {
                // We don't replace any bindings.
                return;
            }

            var valueBinding = BindingOperations.GetBinding(controlBase, controlBase.ValueDependencyProperty);
            if (valueBinding != null)
            {
                var path = $"{OldDataContextProperty.Name}.{valueBinding.Path.Path}";
                oldValueBinding = new Binding(path)
                {
                    Mode = BindingMode.OneWay,
                    Source = controlBase,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };

                BindingOperations.SetBinding(controlBase, OldValueProperty, oldValueBinding);
            }
        }

        private static void OnOldValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var sc = (SettingControlBase)o;
            sc.UpdateIsDirty();
            sc.OnOldValueChanged(e.OldValue, e.NewValue);
        }
    }
}