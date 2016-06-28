namespace Gu.Wpf.PropertyGrid.UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WPFUIItems;

    public static class TextBoxExt
    {
        public static string FormattedText(this TextBox textBox)
        {
            var formatted = (Label)textBox.Get(SearchCriteria.ByControlType(typeof(Label), WindowsFramework.Wpf));
            return formatted.Text;
        }
    }
}