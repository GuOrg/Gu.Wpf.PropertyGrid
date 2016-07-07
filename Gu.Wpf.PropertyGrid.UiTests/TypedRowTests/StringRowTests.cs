namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;

    public class StringRowTests : WindowTests
    {
        private Button loseFocusButton;
        private TextBox currentValueTextBox;
        private TextBox defaultBox;
        private TextBox propertychangedBox;
        private TextBox readonlyBox;

        protected override string WindowName { get; } = "StringRowWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.currentValueTextBox = this.Window.Get<TextBox>("currentValueTextBox");

            this.defaultBox = this.Window.FindRow("default").Value<TextBox>();
            this.propertychangedBox = this.Window.FindRow("propertychanged").Value<TextBox>();
            this.readonlyBox = this.Window.FindRow("readonly string").Value<TextBox>();
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