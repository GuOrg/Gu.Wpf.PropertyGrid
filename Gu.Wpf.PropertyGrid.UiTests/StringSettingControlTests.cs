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

        private TextBox stringBox;
        private TextBox propertychangedBox;
        private TextBox readonlyBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "StringSettingControlWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.stringBox = this.window.FindSetting("string").Get<TextBox>();
            this.propertychangedBox = this.window.FindSetting("propertychanged").Get<TextBox>();
            this.readonlyBox = this.window.FindSetting("readonly string").Get<TextBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.stringBox.Text = string.Empty;
            this.propertychangedBox.Text = string.Empty;

            this.stringBox.Text = "1";
            Assert.AreEqual("1", this.stringBox.Text);
            Assert.AreEqual(string.Empty, this.propertychangedBox.Text);
            Assert.AreEqual(string.Empty, this.readonlyBox.Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("1", this.stringBox.Text);
            Assert.AreEqual("1", this.propertychangedBox.Text);
            Assert.AreEqual("1", this.readonlyBox.Text);
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            this.stringBox.Text = string.Empty;
            this.propertychangedBox.Text = string.Empty;

            this.propertychangedBox.Text = "2";
            Assert.AreEqual("2", this.stringBox.Text);
            Assert.AreEqual("2", this.propertychangedBox.Text);
            Assert.AreEqual("2", this.readonlyBox.Text);
        }

        [Test]
        public void IsReadonly()
        {
            Assert.IsFalse(this.stringBox.IsReadOnly);
            Assert.IsFalse(this.propertychangedBox.IsReadOnly);
            Assert.IsTrue(this.readonlyBox.IsReadOnly);
        }
    }
}