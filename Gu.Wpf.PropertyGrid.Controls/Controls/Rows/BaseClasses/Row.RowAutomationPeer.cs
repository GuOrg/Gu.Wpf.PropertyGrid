namespace Gu.Wpf.PropertyGrid
{
    using System.Windows.Automation.Peers;

    public abstract partial class Row
    {
        private class RowAutomationPeer : FrameworkElementAutomationPeer
        {
            public RowAutomationPeer(Row owner)
                : base(owner)
            {
            }

            protected override string GetClassNameCore()
            {
                return typeof(PropertyGrid).FullName;
            }

            protected override AutomationControlType GetAutomationControlTypeCore()
            {
                return AutomationControlType.Custom;
            }

            protected override string GetNameCore()
            {
                var settingControl = (Row)this.Owner;
                return settingControl.Header;
            }
        }
    }
}