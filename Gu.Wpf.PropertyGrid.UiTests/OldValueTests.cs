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
            groupBox.FindRow("string").Value<TextBox>().Text="abc";
            groupBox.FindRow("double").Value<TextBox>().Text="1.2";
            groupBox.FindRow("length").Value<TextBox>().Text="2.3";
            this.saveButton.Click();
        }

        [Test]
        public void Default()
        {
            var groupBox = this.Window.GetByText<GroupBox>("default");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.OldValue();
            Assert.AreEqual("Old value: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text ="1.23";
            var oldDoubleValue = doubleRow.OldValue();
            Assert.AreEqual("Old value: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.OldValue();
            Assert.AreEqual("Old value: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            Assert.AreEqual(true, oldStringValue.IsOffScreen);
            Assert.AreEqual(true, oldDoubleValue.IsOffScreen);
            Assert.AreEqual(true, oldLengthValue.IsOffScreen);
        }

        [Test]
        public void AttachedProp()
        {
            var groupBox = this.Window.GetByText<GroupBox>("attached prop");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.OldValue();
            Assert.AreEqual("before: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.OldValue();
            Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.OldValue();
            Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            //Assert.AreEqual(true, oldStringValue.IsOffScreen);
            //Assert.AreEqual(true, oldDoubleValue.IsOffScreen);
            //Assert.AreEqual(true, oldLengthValue.IsOffScreen);
        }

        [Test]
        public void Explicit()
        {
            var groupBox = this.Window.GetByText<GroupBox>("explicit");

            var stringRow = groupBox.FindRow("string");
            stringRow.Value<TextBox>().Text = "g";
            var oldStringValue = stringRow.OldValue();
            Assert.AreEqual("before: abc", oldStringValue.Text);

            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text = "1.23";
            var oldDoubleValue = doubleRow.OldValue();
            Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

            var lengthRow = groupBox.FindRow("length");
            lengthRow.Value<TextBox>().Text = "2";
            var oldLengthValue = lengthRow.OldValue();
            Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

            this.saveButton.Click();
            //Assert.AreEqual(true, oldStringValue.IsOffScreen);
            //Assert.AreEqual(true, oldDoubleValue.IsOffScreen);
            //Assert.AreEqual(true, oldLengthValue.IsOffScreen);
        }
    }
}