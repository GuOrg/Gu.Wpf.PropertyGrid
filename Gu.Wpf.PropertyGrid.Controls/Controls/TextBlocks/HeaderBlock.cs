namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    using JetBrains.Annotations;

    public class HeaderBlock : TextBlock
    {
        static HeaderBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderBlock), new FrameworkPropertyMetadata(typeof(HeaderBlock)));
            MarginProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), new Thickness(0, 0, 2, 0));
            VerticalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), VerticalAlignment.Center);
            HorizontalAlignmentProperty.OverrideMetadataWithDefaultValue(typeof(HeaderBlock), HorizontalAlignment.Left);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new HeaderBlockAutomationPeer(this);
        }

        private class HeaderBlockAutomationPeer : TextBlockAutomationPeer
        {
            public HeaderBlockAutomationPeer([NotNull] HeaderBlock owner)
                : base(owner)
            {
            }

            protected override bool IsContentElementCore()
            {
                return true;
            }
        }
    }
}