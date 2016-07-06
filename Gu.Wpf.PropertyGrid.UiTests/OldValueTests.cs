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
            var doubleRow = groupBox.FindRow("double");
            doubleRow.Value<TextBox>().Text ="1.23";
            Assert.AreEqual("Old value: 1.2", doubleRow.OldValue().Text);
        }
    }
}