namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;

    public class OldValueTests : WindowTests
    {
        private Button loseFocusButton;
        private Button saveButton;

        protected override string WindowName { get; } = "OldValueWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.saveButton = this.Window.GetByText<Button>("save");
        }

        [SetUp]
        public void SetUp()
        {
            var groupBox = this.Window.GetByText<GroupBox>("default");
            groupBox.FindRow("string").Value<TextBox>().Text = "abc";
            groupBox.FindRow("double").Value<TextBox>().Text = "1.2";
            groupBox.FindRow("length").Value<TextBox>().Text = "2.3";
            this.saveButton.Click();
        }

        [Test]
        public void Default()
        {
            var groupBox = this.Window.GetByText<GroupBox>("default");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.Info();
            Assert.AreEqual("Old value: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.Info();
            Assert.AreEqual("Old value: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.Info();
            Assert.AreEqual("Old value: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            Assert.AreEqual("", oldStringValue.Text);
            Assert.AreEqual("", oldDoubleValue.Text);
            Assert.AreEqual("", oldLengthValue.Text);
        }

        [Test]
        public void Inherits()
        {
            var groupBox = this.Window.GetByText<GroupBox>("inherits");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.Info();
            Assert.AreEqual("before: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.Info();
            Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.Info();
            Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            Assert.AreEqual("", oldStringValue.Text);
            Assert.AreEqual("", oldDoubleValue.Text);
            Assert.AreEqual("", oldLengthValue.Text);
        }

        [Test]
        public void Explicit()
        {
            var groupBox = this.Window.GetByText<GroupBox>("explicit");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.Info();
            Assert.AreEqual("before: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.Info();
            Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.Info();
            Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            Assert.AreEqual("", oldStringValue.Text);
            Assert.AreEqual("", oldDoubleValue.Text);
            Assert.AreEqual("", oldLengthValue.Text);
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.Window.GetByText<GroupBox>("bound");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.Info();
            Assert.AreEqual("changed", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.Info();
            Assert.AreEqual("changed", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.Info();
            Assert.AreEqual("changed", oldLengthValue.Text);

            groupBox.FindRow("old value format").Value<TextBox>().Text = "before: {0}";
            this.loseFocusButton.Click();

            Assert.AreEqual("before: abc", oldStringValue.Text);
            Assert.AreEqual("before: 1.2", oldDoubleValue.Text);
            Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            Assert.AreEqual("", oldStringValue.Text);
            Assert.AreEqual("", oldDoubleValue.Text);
            Assert.AreEqual("", oldLengthValue.Text);
        }

        [Test]
        public void NoOldValue()
        {
            var partOldValue = "PART_OldValue";
            var groupBox = this.Window.GetByText<GroupBox>("no old datacontext");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            Assert.AreEqual("", stringRow.Info().Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            Assert.AreEqual("", stringRow.Info().Text);
            Assert.AreEqual("", doubleRow.Info().Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            Assert.AreEqual("", stringRow.Info().Text);
            Assert.AreEqual("", doubleRow.Info().Text);
            Assert.AreEqual("", lengthRow.Info().Text);
        }
    }
}