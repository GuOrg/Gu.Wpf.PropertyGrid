namespace Gu.Wpf.PropertyGrid.UiTests
{

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems.WindowItems;

    public class SuffixTests
    {
        private Application application;
        private Window window;

        private Row defaultRow;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "SuffixWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.defaultRow = this.window.FindRow("default");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
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
            Assert.AreEqual("implicit blue", this.window.FindRow("implicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void ExplicitSuffixStyle()
        {
            Assert.AreEqual("explicit pink", this.window.FindRow("explicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void InheritSuffixStyle()
        {
            Assert.AreEqual("inherit khaki", this.window.FindRow("inherit suffixblock style").Suffix().ItemStatus());
        }
    }
}