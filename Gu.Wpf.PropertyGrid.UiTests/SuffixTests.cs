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
            Assert.AreEqual("abc", this.defaultSetting.Suffix().Text);
        }

        [Test]
        public void InheritsTextBlockStyle()
        {
            Assert.AreEqual("Green", this.window.FindSetting("textblock style").Suffix().ItemStatus());
        }

        [Test]
        public void UsesResourceStyle()
        {
            Assert.AreEqual("Blue", this.window.FindSetting("suffixblock style").Suffix().ItemStatus());
        }
    }
}