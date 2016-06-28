namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;

    public static class UiItemExt
    {
        public static string ItemStatus(this IUIItem item)
        {
            return (string)item.AutomationElement.Current.ItemStatus;
        }

        public static T GetByText<T>(this UIItemContainer container, string text)
            where T : UIItem
        {
            return container.Get<T>(SearchCriteria.ByText(text));
        }
    }
}
