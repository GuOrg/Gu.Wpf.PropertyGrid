namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Windows.Automation;
    using Gu.Wpf.UiAutomation;

    public static class AutomationElementExt
    {
        public static Row<TextBox> FindTextBoxRow(this UiElement container, string header)
        {
            return FindRow(container, header, x => new TextBox(x));
        }

        public static Row<ComboBox> FindComboBoxRow(this UiElement container, string header)
        {
            return FindRow(container, header, x => new ComboBox(x));
        }

        public static Row<CheckBox> FindCheckBoxRow(this UiElement container, string header)
        {
            return FindRow(container, header, x => new CheckBox(x));
        }

        public static Row<Button> FindButtonRow(this UiElement container, string header)
        {
            return FindRow(container, header, x => new Button(x));
        }

        public static Row<UiElement> FindRow(this UiElement container, string header)
        {
            return FindRow(container, header, x => new UiElement(x));
        }

        public static Row<T> FindRow<T>(this UiElement container, string header, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return container.FindFirst(
                TreeScope.Children,
                new AndCondition(Conditions.ControlTypeCustom, Conditions.ByNameOrAutomationId(header)),
                x => new Row<T>(x, wrap));
        }

        public static string FormattedText(this TextBox textBox)
        {
            var formatted = textBox.FindTextBlock();
            return formatted.Text;
        }
    }
}
