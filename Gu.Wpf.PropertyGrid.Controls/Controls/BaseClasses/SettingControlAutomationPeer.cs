namespace Gu.Wpf.PropertyGrid
{
    using System.Windows.Automation.Peers;

    public class SettingControlAutomationPeer : UIElementAutomationPeer
    {
        public SettingControlAutomationPeer(SettingControlBase owner)
            : base(owner)
        {
        }

        protected override string GetClassNameCore()
        {
            return typeof(SettingControl).FullName;
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Custom;
        }

        protected override string GetNameCore()
        {
            var settingControl = (SettingControlBase)this.Owner;
            return settingControl.Header;
        }
    }
}