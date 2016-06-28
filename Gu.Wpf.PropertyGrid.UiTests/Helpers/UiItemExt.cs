namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;

    using TestStack.White.UIItems;

    public static class UiItemExt
    {
        public static string ItemStatus(this IUIItem item)
        {
            return (string)item.AutomationElement.Current.ItemStatus;
        }
    }
}
