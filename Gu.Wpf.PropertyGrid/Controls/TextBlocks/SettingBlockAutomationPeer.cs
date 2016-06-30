namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Windows.Automation.Peers;
    using System.Windows.Controls;

    using JetBrains.Annotations;

    internal class SettingBlockAutomationPeer : FrameworkElementAutomationPeer
    {
        private readonly TextBlockAutomationPeer textBlockAutomationPeer;

        public SettingBlockAutomationPeer([NotNull] TextBlock owner)
            : base(owner)
        {
            this.textBlockAutomationPeer = new TextBlockAutomationPeer(owner);
        }

        /// <inheritdoc/>
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return this.textBlockAutomationPeer.GetChildren();
        }

        /// <inheritdoc/>
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Text;
        }

        protected override string GetClassNameCore()
        {
            return "TextBlock";
        }

        protected override bool IsContentElementCore()
        {
            return true;
        }
    }
}