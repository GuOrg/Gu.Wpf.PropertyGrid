namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WPFUIItems;

    public class SettingControl : UIItem
    {
        public SettingControl(UIItem item)
          : base(item.AutomationElement, item.ActionListener)
        {
        }

        public T Get<T>()
            where T : UIItem
        {
            try
            {
                return (T)this.Get(SearchCriteria.ByControlType(typeof(T), WindowsFramework.Wpf));
            }
            catch (AutomationException)
            {
                throw;
            }
            catch (Exception e)
            {
                var debugDetails = Debug.Details(this.automationElement);
                throw new WhiteException($"Error occured while getting {typeof(T).Name}", debugDetails, e);
            }
        }

        public string Suffix(bool mustExist = true)
        {
            try
            {
                var label = (Label)this.Get(SearchCriteria.ByControlType(typeof(Label), WindowsFramework.Wpf).AndAutomationId("SuffixBox"));
                return label.Text;
            }
            catch (Exception)
            {
                if (mustExist)
                {
                    throw;
                }

                return null;
            }
        }
    }
}
