namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Drawing;
    using System.Windows.Automation;

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

        public T Value<T>()
            where T : UIItem
        {
            return this.Get<T>("PART_Value");
        }

        public Label Suffix()
        {
            return this.Get<Label>("PART_Suffix");
        }

#pragma warning disable SA1313 // ReSharper disable once InconsistentNaming we want PART_Name here
        public T Get<T>(string PART_Name)
#pragma warning restore SA1313 // Parameter names must begin with lower-case letter
        {
            try
            {
                return (T)this.Get(SearchCriteria.ByControlType(typeof(T), WindowsFramework.Wpf).AndAutomationId(PART_Name));
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
