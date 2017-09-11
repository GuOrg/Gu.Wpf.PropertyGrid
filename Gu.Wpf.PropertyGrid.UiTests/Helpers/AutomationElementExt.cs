namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using Gu.Wpf.UiAutomation;

    public static class AutomationElementExt
    {
        public static Row<TextBox> FindTextBoxRow(this AutomationElement container, string header)
        {
            return FindRow(container, header, x => new TextBox(x));
        }

        public static Row<T> FindRow<T>(this AutomationElement container, string header, Func<BasicAutomationElementBase, T> wrap)
            where T : AutomationElement
        {
            return container.FindFirst(
                TreeScope.Children,
                container.CreateCondition(ControlType.Custom, header),
                x => new Row<T>(x, wrap));
        }
    }
}