namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Linq;

    using NUnit.Framework;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;

    public class SelectorRowTests : WindowTests
    {
        private Button loseFocusButton;
        private Label currentCultureTextBlock;

        private ComboBox defaultBox;
        private ComboBox lostFocusBox;
        private ComboBox readonlyBox;
        private ComboBox editableBox;

        protected override string WindowName { get; } = "SelectorRowWindow";

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.loseFocusButton = this.Window.GetByText<Button>("lose focus");
            this.currentCultureTextBlock = this.Window.Get<Label>("currentCultureTextBlock");

            this.defaultBox = this.Window.FindRow("default").Value<ComboBox>();
            this.lostFocusBox = this.Window.FindRow("lostfocus").Value<ComboBox>();
            this.readonlyBox = this.Window.FindRow("readonly").Value<ComboBox>();
            this.editableBox = this.Window.FindRow("editable").Value<ComboBox>();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.defaultBox.Select("sv-SE");
            Assert.AreEqual("sv-SE", this.lostFocusBox.SelectedItemText);

            this.lostFocusBox.EditableText = "en-US";
            Assert.AreEqual("sv-SE", this.currentCultureTextBlock.Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("en-US", this.currentCultureTextBlock.Text);
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            this.defaultBox.Select("en-US");
            Assert.AreEqual("en-US", this.currentCultureTextBlock.Text);
            Assert.AreEqual("en-US", this.defaultBox.SelectedItemText);
            Assert.AreEqual("en-US", this.lostFocusBox.SelectedItemText);
            Assert.AreEqual("en-US", this.readonlyBox.SelectedItemText);
            Assert.AreEqual("en-US", this.editableBox.SelectedItemText);

            this.defaultBox.Select("sv-SE");
            Assert.AreEqual("sv-SE", this.currentCultureTextBlock.Text);
            Assert.AreEqual("sv-SE", this.defaultBox.SelectedItemText);
            Assert.AreEqual("sv-SE", this.lostFocusBox.SelectedItemText);
            Assert.AreEqual("sv-SE", this.readonlyBox.SelectedItemText);
            Assert.AreEqual("sv-SE", this.editableBox.SelectedItemText);
        }

        [Test]
        public void IsEditable()
        {
            Assert.False(this.defaultBox.IsEditable);
            Assert.True(this.lostFocusBox.IsEditable);
            Assert.False(this.readonlyBox.IsEditable);
            Assert.True(this.editableBox.IsEditable);
        }

        [Test]
        public void Items()
        {
            var expected = new[] { "sv-SE", "en-US" };
            CollectionAssert.AreEqual(expected, this.defaultBox.Items.AsReadOnly().Select(x => x.Text));
            CollectionAssert.AreEqual(expected, this.lostFocusBox.Items.AsReadOnly().Select(x => x.Text));
            CollectionAssert.AreEqual(expected, this.readonlyBox.Items.AsReadOnly().Select(x => x.Text));
        }
    }
}