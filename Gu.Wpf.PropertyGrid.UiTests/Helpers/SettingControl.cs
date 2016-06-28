namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.Sessions;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Container;
    using TestStack.White.UIItems.Finders;

    public class SettingControl : UIItem
    {
        private static readonly WindowSession WindowSession = new NullWindowSession();
        private readonly UIItem item;
        private readonly CurrentContainerItemFactory itemFactory;

        public SettingControl(UIItem item)
          : base(item.AutomationElement, item.ActionListener)
        {
            this.item = item;
            this.itemFactory = new CurrentContainerItemFactory(this.factory, InitializeOption.NoCache, this.automationElement, this.actionListener);
        }

        public T Get<T>()
            where T : UIItem
        {
            try
            {
                var uiItem = this.itemFactory.Find(SearchCriteria.ByControlType(typeof(T), WindowsFramework.Wpf), WindowSession);
                return (T)uiItem;
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
    }
}
