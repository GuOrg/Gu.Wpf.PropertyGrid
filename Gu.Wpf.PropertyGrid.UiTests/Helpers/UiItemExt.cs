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

        public static bool HasValidationError(this UIItem item)
        {
            var itemStatus = item.ItemStatus();
            if (itemStatus.Contains("HasError: True"))
            {
                return true;
            }

            if (itemStatus.Contains("HasError: False"))
            {
                return false;
            }

            throw new InvalidOperationException();
        }
    }
}
