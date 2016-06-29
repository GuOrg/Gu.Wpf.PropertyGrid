namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    public class SuffixBlock : TextBlock
    {
        static SuffixBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SuffixBlock), new FrameworkPropertyMetadata(typeof(SuffixBlock)));
            MarginProperty.OverrideMetadataWithDefaultValue(typeof(SuffixBlock), new Thickness(2, 0, 0, 0));
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(SuffixBlock), VerticalAlignment.Center);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(SuffixBlock), HorizontalAlignment.Left);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingBlockAutomationPeer(this);
        }
    }
}
