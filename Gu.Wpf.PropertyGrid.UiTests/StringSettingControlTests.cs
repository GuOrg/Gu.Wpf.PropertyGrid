namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class StringSettingControlTests
    {
        private Application application;
        private Window window;
        private Button loseFocusButton;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "StringSettingControlWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void SvSe()
        {
            var groupBox = this.window.GetByText<GroupBox>("sv-se");
            var doubleBox = groupBox.FindSetting("double").Get<TextBox>();
            var lengthBox = groupBox.FindSetting("length").Get<TextBox>();

            Assert.AreEqual("0,00", doubleBox.FormattedText());
            Assert.AreEqual("12,35", lengthBox.FormattedText());
        }

        [Test]
        public void EnUs()
        {
            var groupBox = this.window.GetByText<GroupBox>("en-us");
            var doubleBox = groupBox.FindSetting("double").Get<TextBox>();
            var lengthBox = groupBox.FindSetting("length").Get<TextBox>();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.window.GetByText<GroupBox>("bound");
            var doubleBox = groupBox.FindSetting("double").Get<TextBox>();
            var lengthBox = groupBox.FindSetting("length").Get<TextBox>();
            var cultureBox = groupBox.FindSetting("culture").Get<TextBox>();

            Assert.AreEqual("0,00", doubleBox.FormattedText());
            Assert.AreEqual("12,35", lengthBox.FormattedText());

            cultureBox.Text = "en-us";
            this.loseFocusButton.Click();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }
    }
}