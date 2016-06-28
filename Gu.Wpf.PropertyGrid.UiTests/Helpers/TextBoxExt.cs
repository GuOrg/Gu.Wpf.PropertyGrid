namespace Gu.Wpf.PropertyGrid.UiTests
{
    using TestStack.White.UIItems;

    public static class TextBoxExt
    {
        public static string ItemStatus(this IUIItem item)
        {
            return (string)item.AutomationElement.Current.ItemStatus;
        }
    }
}