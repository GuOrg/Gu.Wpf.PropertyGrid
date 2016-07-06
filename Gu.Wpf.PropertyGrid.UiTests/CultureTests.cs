namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;

    public class CultureTests : WindowTests
    {
        private Button loseFocusButton;
        protected override string WindowName { get; } = "CultureWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
        }

        [Test]
        public void SvSe()
        {
            var groupBox = this.Window.GetByText<GroupBox>("sv-se");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0,0000", doubleBox.FormattedText());
            Assert.AreEqual("0,0123", lengthBox.FormattedText());
        }

        [Test]
        public void EnUs()
        {
            var groupBox = this.Window.GetByText<GroupBox>("en-us");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0.0000", doubleBox.FormattedText());
            Assert.AreEqual("0.0123", lengthBox.FormattedText());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.Window.GetByText<GroupBox>("bound");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();
            var cultureBox = groupBox.FindRow("culture").Value<ComboBox>();

            Assert.AreEqual("0,0000", doubleBox.FormattedText());
            Assert.AreEqual("0,0123", lengthBox.FormattedText());

            cultureBox.Select("en-US");
            this.loseFocusButton.Click();

            Assert.AreEqual("0.0000", doubleBox.FormattedText());
            Assert.AreEqual("0.0123", lengthBox.FormattedText());
        }
    }
}