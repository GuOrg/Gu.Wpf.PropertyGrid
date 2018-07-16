namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    /// <summary>
    /// The text block used for rendering the header text.
    /// </summary>
    public class HeaderBlock : TextBlock
    {
        static HeaderBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderBlock), new FrameworkPropertyMetadata(typeof(HeaderBlock)));
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), VerticalAlignment.Center);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), HorizontalAlignment.Left);
        }

        /// <inheritdoc />
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingBlockAutomationPeer(this);
        }
    }
}
