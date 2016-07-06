namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    public class OldValueBlock : TextBlock
    {
        static OldValueBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OldValueBlock), new FrameworkPropertyMetadata(typeof(OldValueBlock)));
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(OldValueBlock), VerticalAlignment.Top);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(OldValueBlock), HorizontalAlignment.Right);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingBlockAutomationPeer(this);
        }
    }
}