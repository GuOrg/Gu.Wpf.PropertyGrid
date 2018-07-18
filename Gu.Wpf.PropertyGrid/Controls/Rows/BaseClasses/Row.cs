namespace Gu.Wpf.PropertyGrid
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public abstract partial class Row : Control
    {
        private readonly List<DependencyObject> logicalChildren = new List<DependencyObject>();

        static Row()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(typeof(Row)));
            FocusableProperty.OverrideMetadata(typeof(Row), new FrameworkPropertyMetadata(BooleanBoxes.False));
        }

        /// <inheritdoc />
        protected override IEnumerator LogicalChildren => this.logicalChildren.GetEnumerator();

        /// <inheritdoc/>
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return new RowAutomationPeer(this);
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
    }
}
