namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Linq;

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class SelectorRowTests
    {
        private Application application;
        private Window window;
        private Button loseFocusButton;
        private Label currentCultureTextBlock;

        private ComboBox defaultBox;
        private ComboBox lostFocusBox;
        private ComboBox readonlyBox;
        private ComboBox editableBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "SelectorRowWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.currentCultureTextBlock = this.window.Get<Label>("currentCultureTextBlock");

            this.defaultBox = this.window.FindRow("default").Value<ComboBox>();
            this.lostFocusBox = this.window.FindRow("lostfocus").Value<ComboBox>();
            this.readonlyBox = this.window.FindRow("readonly").Value<ComboBox>();
            this.editableBox = this.window.FindRow("editable").Value<ComboBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
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