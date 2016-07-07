namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White.UIItems;

    public class IntRowTests : WindowTests
    {
        private Button loseFocusButton;
        private TextBox currentValueTextBox;

        private TextBox defaultBox;
        private TextBox propertychangedBox;
        private TextBox readonlyBox;
        private TextBox currentNullableValueTextBox;
        private TextBox nullableBox;

        protected override string WindowName { get; } = "IntRowWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.currentValueTextBox = this.Window.Get<TextBox>("currentValueTextBox");
            this.currentNullableValueTextBox = this.Window.Get<TextBox>("currentNullableValueTextBox");

            this.defaultBox = this.Window.FindRow("default").Value<TextBox>();
            this.propertychangedBox = this.Window.FindRow("propertychanged").Value<TextBox>();
            this.readonlyBox = this.Window.FindRow("readonly").Value<TextBox>();
            this.nullableBox = this.Window.FindRow("nullable").Value<TextBox>();
        }

        [SetUp]
        public void SetUp()
        {
            this.currentValueTextBox.Text = "1";
            this.currentNullableValueTextBox.Text = "1";
            this.loseFocusButton.Click();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.defaultBox.Text = "2";
            Assert.AreEqual("2", this.defaultBox.Text);
            Assert.AreEqual("1", this.propertychangedBox.Text);
            Assert.AreEqual("1", this.readonlyBox.Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("2", this.defaultBox.Text);
            Assert.AreEqual("2", this.propertychangedBox.Text);
            Assert.AreEqual("2", this.readonlyBox.Text);
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