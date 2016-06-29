namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Media;

    public abstract partial class SettingControlBase
    {
        private class SettingControlAutomationPeer : FrameworkElementAutomationPeer
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
}