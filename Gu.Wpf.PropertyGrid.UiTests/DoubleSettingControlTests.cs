namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class DoubleSettingControlTests
    {
        private Application application;
        private Window window;
        private Button loseFocusButton;
        private TextBox currentValueTextBox;

        private TextBox defaultBox;
        private TextBox propertychangedBox;
        private TextBox readonlyBox;
        private TextBox currentNullableValueTextBox;
        private TextBox nullableBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "DoubleSettingControlWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.currentValueTextBox = this.window.Get<TextBox>("currentValueTextBox");
            this.currentNullableValueTextBox = this.window.Get<TextBox>("currentNullableValueTextBox");

            this.defaultBox = this.window.FindSetting("default").Value<TextBox>();
            this.propertychangedBox = this.window.FindSetting("propertychanged").Value<TextBox>();
            this.readonlyBox = this.window.FindSetting("readonly").Value<TextBox>();
            this.nullableBox = this.window.FindSetting("nullable").Value<TextBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            this.currentValueTextBox.Text = "0.0123456";
            this.currentNullableValueTextBox.Text = "0.0123456";
            this.loseFocusButton.Click();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.defaultBox.Text = "1";
            Assert.AreEqual("1", this.defaultBox.Text);
            Assert.AreEqual("0.0123456", this.propertychangedBox.Text);
            Assert.AreEqual("0.0123456", this.readonlyBox.Text);

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
        public void Nullable()
        {
            this.nullableBox.Text = "";
            this.loseFocusButton.Click();

            Assert.AreEqual("null", this.currentNullableValueTextBox.Text);
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