namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using Gu.Wpf.UiAutomation;

    public class Row<T> : AutomationElement
        where T : AutomationElement
    {
        private readonly Func<BasicAutomationElementBase, T> wrap;

        public Row(BasicAutomationElementBase item, Func<BasicAutomationElementBase, T> wrap)
            : base(item)
        {
            this.wrap = wrap;
        }

        public T Value()
        {
            return this.FindFirst(TreeScope.Children, this.ConditionFactory.ByAutomationId("PART_Value"), x => this.wrap(x));
        }

        public TextBlock Suffix()
        {
            return this.FindTextBlock("PART_Suffix");
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
