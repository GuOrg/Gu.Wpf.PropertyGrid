namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    [TemplatePart(Name = ValueBoxName, Type = typeof(FrameworkElement))]
    public abstract partial class Row : Control
    {
        private readonly List<DependencyObject> logicalChildren = new List<DependencyObject>();

        /// <summary>
        /// The name of the template child used to edit the Value property
        /// </summary>
        public const string ValueBoxName = "PART_Value";

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

        /// <summary>
        /// Gets the dependency property for the value of this row.
        /// </summary>
        protected DependencyProperty ValueDependencyProperty { get; }

        /// <inheritdoc />
        protected override IEnumerator LogicalChildren => this.logicalChildren.GetEnumerator();

        /// <inheritdoc/>
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return new RowAutomationPeer(this);
        }

        /// <summary>
        /// Update the value of the <see cref="Row.IsDirty"/> property
        /// </summary>
        protected abstract void UpdateIsDirty();

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
    }
}
