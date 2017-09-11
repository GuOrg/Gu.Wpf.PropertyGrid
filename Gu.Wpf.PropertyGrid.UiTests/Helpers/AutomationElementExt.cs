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

        public static Row<ComboBox> FindComboBoxRow(this AutomationElement container, string header)
        {
            return FindRow(container, header, x => new ComboBox(x));
        }

        public static Row<T> FindRow<T>(this AutomationElement container, string header, Func<BasicAutomationElementBase, T> wrap)
            where T : AutomationElement
        {
            return container.FindFirst(
                TreeScope.Children,
                container.CreateCondition(ControlType.Custom, header),
                x => new Row<T>(x, wrap));
        }

        public static string FormattedText(this TextBox textBox)
        {
            var formatted = textBox.FindTextBlock();
            return formatted.Text;
        }
    }
}