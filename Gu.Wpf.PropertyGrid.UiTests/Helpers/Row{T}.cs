namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Windows.Automation;
    using Gu.Wpf.UiAutomation;

    public class Row<T> : UiElement
        where T : UiElement
    {
        private readonly Func<AutomationElement, T> wrap;

        public Row(AutomationElement item, Func<AutomationElement, T> wrap)
            : base(item)
        {
            this.wrap = wrap;
        }

        public T Value()
        {
            return this.FindFirst(TreeScope.Children, Conditions.ByAutomationId("PART_Value"), x => this.wrap(x));
        }

        public TextBlock Header()
        {
            return this.FindAt(TreeScope.Children, Conditions.TextBlock, 0, x => new TextBlock(x), TimeSpan.FromSeconds(1));
        }

        public TextBlock Suffix()
        {
            return this.FindAt(TreeScope.Children, Conditions.TextBlock, 1, x => new TextBlock(x), TimeSpan.FromSeconds(1));
        }

        public TextBlock Info()
        {
            return this.FindTextBlock("PART_Info");
        }

        public double[] ColumnsWidths()
        {
            var valueBounds = this.Value().Bounds;
            return new[]
            {
                valueBounds.Left - this.Bounds.Left,
                valueBounds.Width,
                this.Bounds.Right - valueBounds.Right
            };
        }
    }
}
