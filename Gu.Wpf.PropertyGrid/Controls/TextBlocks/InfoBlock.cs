namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    public class InfoBlock : TextBlock
    {
        static InfoBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoBlock), new FrameworkPropertyMetadata(typeof(InfoBlock)));
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(InfoBlock), VerticalAlignment.Top);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(InfoBlock), HorizontalAlignment.Right);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingBlockAutomationPeer(this);
        }
    }
}