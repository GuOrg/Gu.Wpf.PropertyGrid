namespace Gu.Wpf.PropertyGrid.UiTests
{

    using NUnit.Framework;

    public class SuffixTests : WindowTests
    {
        private Row defaultRow;

        protected override string WindowName { get; } = "SuffixWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.defaultRow = this.Window.FindRow("default");
        }

        [Test]
        public void Default()
        {
            Assert.AreEqual("suffix", this.defaultRow.Suffix().Text);
        }

        [Test]
        public void UsesResourceStyle()
        {
            Assert.Inconclusive("not sure how to test this.");
            Assert.AreEqual("implicit blue", this.Window.FindRow("implicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void ExplicitSuffixStyle()
        {
            Assert.AreEqual("explicit pink", this.Window.FindRow("explicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void InheritSuffixStyle()
        {
            Assert.AreEqual("inherit khaki", this.Window.FindRow("inherit suffixblock style").Suffix().ItemStatus());
        }
    }
}