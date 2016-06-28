namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Custom;
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

        public static SettingControl FindSetting(this UIItemContainer container, string header)
        {
            var uiItem = container.Get<UIItem>(SearchCriteria.ByText(header));
            return new SettingControl(uiItem);
        }
    }
}
