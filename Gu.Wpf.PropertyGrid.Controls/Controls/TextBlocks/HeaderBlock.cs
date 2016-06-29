namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    public class HeaderBlock : TextBlock
    {
        static HeaderBlock()
        {
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), VerticalAlignment.Center);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), HorizontalAlignment.Left);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingBlockAutomationPeer(this);
        }
    }
}