namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class StringRowTests
    {
        private Application application;
        private Window window;
        private Button loseFocusButton;

        private TextBox defaultBox;
        private TextBox propertychangedBox;
        private TextBox readonlyBox;

        private TextBox currentValueTextBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "StringRowWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.currentValueTextBox = this.window.Get<TextBox>("currentValueTextBox");

            this.defaultBox = this.window.FindRow("default").Value<TextBox>();
            this.propertychangedBox = this.window.FindRow("propertychanged").Value<TextBox>();
            this.readonlyBox = this.window.FindRow("readonly string").Value<TextBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            this.currentValueTextBox.Text = string.Empty;
            this.loseFocusButton.Click();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.defaultBox.Text = "1";
            Assert.AreEqual("1", this.defaultBox.Text);
            Assert.AreEqual(string.Empty, this.propertychangedBox.Text);
            Assert.AreEqual(string.Empty, this.readonlyBox.Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("1", this.defaultBox.Text);
            Assert.AreEqual("1", this.propertychangedBox.Text);
            Assert.AreEqual("1", this.readonlyBox.Text);
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            this.propertychangedBox.Text = "2";
            Assert.AreEqual("2", this.defaultBox.Text);
            Assert.AreEqual("2", this.propertychangedBox.Text);
            Assert.AreEqual("2", this.readonlyBox.Text);
        }

        [Test]
        public void IsReadonly()
        {
            Assert.IsFalse(this.defaultBox.IsReadOnly);
            Assert.IsFalse(this.propertychangedBox.IsReadOnly);
            Assert.IsTrue(this.readonlyBox.IsReadOnly);
        }
    }
}