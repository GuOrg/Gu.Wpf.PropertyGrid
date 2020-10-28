namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    /// <inheritdoc />
    internal class SettingBlockAutomationPeer : FrameworkElementAutomationPeer
    {
        private readonly TextBlockAutomationPeer textBlockAutomationPeer;

        /// <inheritdoc />
        public SettingBlockAutomationPeer(TextBlock owner)
            : base(owner)
        {
            this.textBlockAutomationPeer = new TextBlockAutomationPeer(owner);
        }

        /// <inheritdoc/>
        protected override List<AutomationPeer> GetChildrenCore() => this.textBlockAutomationPeer.GetChildren();

        /// <inheritdoc/>
        protected override AutomationControlType GetAutomationControlTypeCore() => AutomationControlType.Text;

        /// <inheritdoc />
        protected override string GetClassNameCore() => "TextBlock";

        /// <inheritdoc />
        protected override bool IsContentElementCore() => true;
    }
}
