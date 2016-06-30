namespace Gu.Wpf.PropertyGrid.UiTests
{

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems.WindowItems;

    public class SuffixTests
    {
        private Application application;
        private Window window;

        private SettingControl defaultSetting;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "SuffixWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.defaultSetting = this.window.FindSetting("default");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void Default()
        {
            Assert.AreEqual("suffix", this.defaultSetting.Suffix().Text);
        }

        [Test]
        public void UsesResourceStyle()
        {
            Assert.Inconclusive("not sure how to test this.");
            Assert.AreEqual("implicit blue", this.window.FindSetting("implicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void ExplicitSuffixStyle()
        {
            Assert.AreEqual("explicit pink", this.window.FindSetting("explicit suffixblock style").Suffix().ItemStatus());
        }

        [Test]
        public void InheritSuffixStyle()
        {
            Assert.AreEqual("inherit khaki", this.window.FindSetting("inherit suffixblock style").Suffix().ItemStatus());
        }
    }
}