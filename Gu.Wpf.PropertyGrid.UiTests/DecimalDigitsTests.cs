namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;

    public class DecimalDigitsTests : WindowTests
    {
        private Button loseFocusButton;

        protected override string WindowName { get; } = "DecimalDigitsWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
           base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
        }

        [Test]
        public void Inherits()
        {
            var groupBox = this.Window.GetByText<GroupBox>("attached prop");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }

        [Test]
        public void Explicit()
        {
            var groupBox = this.Window.GetByText<GroupBox>("explicit");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.Window.GetByText<GroupBox>("bound");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();
            var digitsBox = groupBox.FindRow("digits").Value<TextBox>();

            Assert.AreEqual("0.000", doubleBox.FormattedText());
            Assert.AreEqual("12.346", lengthBox.FormattedText());

            digitsBox.Text = "2";
            this.loseFocusButton.Click();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }
    }
}