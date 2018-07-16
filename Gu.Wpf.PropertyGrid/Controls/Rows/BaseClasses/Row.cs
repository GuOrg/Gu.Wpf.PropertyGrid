namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Threading;

    [TemplatePart(Name = ValueBoxName, Type = typeof(FrameworkElement))]
    public abstract partial class Row : Control
    {
        private readonly List<DependencyObject> logicalChildren = new List<DependencyObject>();

        /// <summary>
        /// The name of the template child used to edit the Value property
        /// </summary>
        public const string ValueBoxName = "PART_Value";

        /// <summary>
        /// Gets the dependency property for the value of this row.
        /// </summary>
        protected DependencyProperty ValueDependencyProperty { get; }

        static Row()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(typeof(Row)));
            FocusableProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Row"/> class.
        /// </summary>
        /// <param name="valueDependencyProperty">The dependency property containing the value.</param>
        protected Row(DependencyProperty valueDependencyProperty)
        {
            this.ValueDependencyProperty = valueDependencyProperty;
        }

        /// <inheritdoc />
        protected override IEnumerator LogicalChildren => this.logicalChildren.GetEnumerator();

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
            this.UpdateLogicalChild(oldValue as DependencyObject, newValue as DependencyObject);
        }

        /// <inheritdoc />
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

        /// <summary>
        /// Call <see cref="FrameworkElement.RemoveLogicalChild"/> with <paramref name="oldChild"/> and <see cref="FrameworkElement.AddLogicalChild"/> with <paramref name="newChild"/>
        /// And update <see cref="FrameworkElement.LogicalChildren"/>
        /// </summary>
        /// <param name="oldChild">The old child.</param>
        /// <param name="newChild">The new child.</param>
        protected virtual void UpdateLogicalChild(DependencyObject oldChild, DependencyObject newChild)
        {
            if (oldChild != null)
            {
                this.RemoveLogicalChild(oldChild);
                this.logicalChildren.Remove(oldChild);
            }

            if (newChild != null)
            {
                this.AddLogicalChild(newChild);
                this.logicalChildren.Add(newChild);
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
            var row = (Row)o;
            row.UpdateIsDirty();
            row.OnOldValueChanged(e.OldValue, e.NewValue);
        }
    }
}
