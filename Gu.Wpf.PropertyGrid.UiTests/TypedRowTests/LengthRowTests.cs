namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;

    public class LengthRowTests : WindowTests
    {
        private Button loseFocusButton;
        private Button saveButton;
        private TextBox currentValueTextBox;
        private TextBox currentNullableValueTextBox;
        private TextBox currentMinValueTextBox;
        private TextBox currentMaxValueTextBox;

        private Row defaultRow;
        private Row propertychangedRow;
        private Row readonlyRow;
        private Row nullableRow;
        private Row cmRow;


        protected override string WindowName { get; } = "LengthRowWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.saveButton = this.Window.GetByText<Button>("save");
            this.currentValueTextBox = this.Window.Get<TextBox>("currentValueTextBox");
            this.currentMinValueTextBox = this.Window.Get<TextBox>("currentMinValueTextBox");
            this.currentMaxValueTextBox = this.Window.Get<TextBox>("currentMaxValueTextBox");
            this.currentNullableValueTextBox = this.Window.Get<TextBox>("currentNullableValueTextBox");

            this.defaultRow = this.Window.FindRow("default");
            this.propertychangedRow = this.Window.FindRow("propertychanged");
            this.readonlyRow = this.Window.FindRow("readonly");
            this.nullableRow = this.Window.FindRow("nullable");
            this.cmRow = this.Window.FindRow("explicit cm");
        }

        [SetUp]
        public void SetUp()
        {
            this.currentValueTextBox.Text = "1.23 m";
            this.currentMinValueTextBox.Text = "";
            this.currentMaxValueTextBox.Text = "";
            this.currentNullableValueTextBox.Text = "";
            this.loseFocusButton.Click();
            if (this.saveButton.Enabled)
            {
                this.saveButton.Click();
            }
        }

        [Test]
        public void Initializes()
        {
            Assert.AreEqual("\u00A0m", this.defaultRow.Suffix().Text);
            Assert.AreEqual("1.23", this.defaultRow.Value<TextBox>().Text);

            Assert.AreEqual("\u00A0m", this.propertychangedRow.Suffix().Text);
            Assert.AreEqual("1.23", this.propertychangedRow.Value<TextBox>().Text);

            Assert.AreEqual("\u00A0m", this.readonlyRow.Suffix().Text);
            Assert.AreEqual("1.23", this.readonlyRow.Value<TextBox>().Text);

            Assert.AreEqual("\u00A0m", this.readonlyRow.Suffix().Text);
            Assert.AreEqual("", this.nullableRow.Value<TextBox>().Text);

            Assert.AreEqual("\u00A0cm", this.cmRow.Suffix().Text);
            Assert.AreEqual("123", this.cmRow.Value<TextBox>().Text);
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.defaultRow.Value<TextBox>().Text = "2.3";
            Assert.AreEqual("2.3", this.defaultRow.Value<TextBox>().Text);
            Assert.AreEqual("Old value: 1.23 m", this.defaultRow.Info().Text);
            Assert.AreEqual("1.23", this.propertychangedRow.Value<TextBox>().Text);
            Assert.AreEqual("", this.propertychangedRow.Info().Text);
            Assert.AreEqual("1.23", this.readonlyRow.Value<TextBox>().Text);
            Assert.AreEqual("123", this.cmRow.Value<TextBox>().Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("2.3", this.defaultRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.propertychangedRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.readonlyRow.Value<TextBox>().Text);
            Assert.AreEqual("230", this.cmRow.Value<TextBox>().Text);
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            this.propertychangedRow.Value<TextBox>().Text = "2.3";
            Assert.AreEqual("2.3", this.defaultRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.propertychangedRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.readonlyRow.Value<TextBox>().Text);
            Assert.AreEqual("230", this.cmRow.Value<TextBox>().Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("2.3", this.defaultRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.propertychangedRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.readonlyRow.Value<TextBox>().Text);
            Assert.AreEqual("230", this.cmRow.Value<TextBox>().Text);
        }

        [Test]
        public void UpdatesWhenViewModelChanges()
        {
            this.currentValueTextBox.Text = "2.3 m";
            this.loseFocusButton.Click();
            Assert.AreEqual("2.3", this.defaultRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.propertychangedRow.Value<TextBox>().Text);
            Assert.AreEqual("2.3", this.readonlyRow.Value<TextBox>().Text);
            Assert.AreEqual("230", this.cmRow.Value<TextBox>().Text);
        }

        [Test]
        public void WhenUserTypesInGreaterThanMax()
        {
            this.currentMaxValueTextBox.Text = "2.3 m";
            this.defaultRow.Value<TextBox>().Text = "2.4";
            Assert.AreEqual("Old value: 1.23 m", this.defaultRow.Info().Text);
            this.loseFocusButton.Click();

            Assert.AreEqual("2,4 > max (2,3)", this.defaultRow.Info().Text);
            Assert.AreEqual("2.3\u00A0m", this.currentValueTextBox.Text);
        }

        [Test]
        public void WhenUserTypesInGreaterThanMaxCm()
        {
            this.currentMaxValueTextBox.Text = "2.3 m";
            this.cmRow.Value<TextBox>().Text = "240";
            Assert.AreEqual("Old value: 123 m", this.cmRow.Info().Text);
            this.loseFocusButton.Click();

            Assert.AreEqual("240 > max (230)", this.defaultRow.Info().Text);
            Assert.AreEqual("2.3\u00A0m", this.currentValueTextBox.Text);
        }


        [Test]
        public void WhenUserTypesInLessThanMin()
        {
            this.currentMinValueTextBox.Text = "-2.3 m";
            this.defaultRow.Value<TextBox>().Text = "-2.4";
            Assert.AreEqual("Old value: 1.23 m", this.defaultRow.Info().Text);
            this.loseFocusButton.Click();

            Assert.AreEqual("-2,4 < min (-2,3)", this.defaultRow.Info().Text);
            Assert.AreEqual("2.3\u00A0m", this.currentValueTextBox.Text);
        }

        [Test]
        public void WhenUserTypesInLessThanMinCm()
        {
            this.currentMinValueTextBox.Text = "-2.3 m";
            this.cmRow.Value<TextBox>().Text = "240";
            Assert.AreEqual("Old value: 1.23 m", this.defaultRow.Info().Text);
            this.loseFocusButton.Click();

            Assert.AreEqual("-240 < min (-230)", this.defaultRow.Info().Text);
            Assert.AreEqual("2.3\u00A0m", this.currentValueTextBox.Text);
        }
    }
}