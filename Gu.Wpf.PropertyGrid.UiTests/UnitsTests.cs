namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;

    public class UnitsTests : WindowTests
    {
        private Button loseFocusButton;
        private TextBox currentValueTextBox;

        protected override string WindowName { get; } = "UnitsWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.currentValueTextBox = this.Window.Get<TextBox>("currentValueTextBox");
        }

        [SetUp]
        public void SetUp()
        {
            this.currentValueTextBox.Text = "0.0123456 m";
            this.loseFocusButton.Click();
        }

        [Test]
        public void ExplicitUnits()
        {
            var groupBox = this.Window.GetByText<GroupBox>("explicit");
            var metresSetting = groupBox.FindRow("length (m)");
            var metresBox = metresSetting.Value<TextBox>();
            var millimetresSetting = groupBox.FindRow("length (mm)");
            var millimetresBox = millimetresSetting.Value<TextBox>();

            Assert.AreEqual("0.0123456", metresBox.Text);
            Assert.AreEqual("\u00A0m", metresSetting.Suffix().Text);
            Assert.AreEqual("12.3456", millimetresBox.Text);
            Assert.AreEqual("\u00A0mm", millimetresSetting.Suffix().Text);

            metresBox.Text = "2.4";
            this.loseFocusButton.Click();
            Assert.AreEqual("2400", millimetresBox.Text);
        }

        [Test]
        public void UnitFromStyle()
        {
            var groupBox = this.Window.GetByText<GroupBox>("style");
            var settingControl = groupBox.FindRow("length");
            var textBox = settingControl.Value<TextBox>();

            Assert.AreEqual("12.3456", textBox.Text);
            Assert.AreEqual("\u00A0mm", settingControl.Suffix().Text);

            textBox.Text = "2";
            Assert.AreEqual("0.0123456\u00A0m", this.currentValueTextBox.Text);
            this.loseFocusButton.Click();
            Assert.AreEqual("0.002\u00A0m", this.currentValueTextBox.Text);
        }

        [Test]
        public void BoundUnit()
        {
            var groupBox = this.Window.GetByText<GroupBox>("bound");
            var settingControl = groupBox.FindRow("length");
            var textBox = settingControl.Value<TextBox>();

            Assert.AreEqual("1.23456", textBox.Text);
            Assert.AreEqual("\u00A0cm", settingControl.Suffix().Text);

            groupBox.FindRow("selector").Value<ComboBox>().Select("m");

            Assert.AreEqual("0.0123456", textBox.Text);
            Assert.AreEqual("\u00A0m", settingControl.Suffix().Text);
        }
    }
}