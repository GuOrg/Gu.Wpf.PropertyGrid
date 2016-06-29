namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class EnumSettingControlTests
    {
        private Application application;
        private Window window;
        private Button loseFocusButton;
        private Label currentCultureTextBlock;

        private ComboBox currentBox;
        private ComboBox lostFocusBox;
        private ComboBox readonlyBox;
        private ComboBox editableBox;
        private ComboBox explicitTypeBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "EnumSettingControlWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.currentCultureTextBlock = this.window.Get<Label>("currentTextBlock");

            this.currentBox = this.window.FindSetting("current").Value<ComboBox>();
            this.explicitTypeBox = this.window.FindSetting("explicit_type").Value<ComboBox>();
            this.lostFocusBox = this.window.FindSetting("lostfocus").Value<ComboBox>();
            this.readonlyBox = this.window.FindSetting("readonly").Value<ComboBox>();
            this.editableBox = this.window.FindSetting("editable").Value<ComboBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            this.currentBox.Select("CurrentCultureIgnoreCase");
            Assert.AreEqual("CurrentCultureIgnoreCase", this.currentCultureTextBlock.Text);

            this.lostFocusBox.EditableText = "InvariantCulture";
            Assert.AreEqual("CurrentCultureIgnoreCase", this.currentCultureTextBlock.Text);

            this.loseFocusButton.Click();
            Assert.AreEqual("InvariantCulture", this.currentCultureTextBlock.Text);
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            this.currentBox.Select("CurrentCultureIgnoreCase");
            Assert.AreEqual("CurrentCultureIgnoreCase", this.currentCultureTextBlock.Text);
            Assert.AreEqual("CurrentCultureIgnoreCase", this.currentBox.SelectedItemText);
            Assert.AreEqual("CurrentCultureIgnoreCase", this.lostFocusBox.SelectedItemText);
            Assert.AreEqual("CurrentCultureIgnoreCase", this.readonlyBox.SelectedItemText);
            Assert.AreEqual("CurrentCultureIgnoreCase", this.editableBox.SelectedItemText);

            this.currentBox.Select("Ordinal");
            Assert.AreEqual("Ordinal", this.currentCultureTextBlock.Text);
            Assert.AreEqual("Ordinal", this.currentBox.SelectedItemText);
            Assert.AreEqual("Ordinal", this.lostFocusBox.SelectedItemText);
            Assert.AreEqual("Ordinal", this.readonlyBox.SelectedItemText);
            Assert.AreEqual("Ordinal", this.editableBox.SelectedItemText);
        }

        [Test]
        public void IsEditable()
        {
            Assert.False(this.currentBox.IsEditable);
            Assert.True(this.lostFocusBox.IsEditable);
            Assert.False(this.readonlyBox.IsEditable);
            Assert.True(this.editableBox.IsEditable);
        }

        [Test]
        public void Items()
        {
            var expected = new[] { "CurrentCulture", "CurrentCultureIgnoreCase", "InvariantCulture", "InvariantCultureIgnoreCase", "Ordinal", "OrdinalIgnoreCase" };
            CollectionAssert.AreEqual(expected, this.currentBox.Items.AsReadOnly().Select(x => x.Text));
            CollectionAssert.AreEqual(expected, this.explicitTypeBox.Items.AsReadOnly().Select(x => x.Text));
            CollectionAssert.AreEqual(expected, this.lostFocusBox.Items.AsReadOnly().Select(x => x.Text));
            CollectionAssert.AreEqual(expected, this.readonlyBox.Items.AsReadOnly().Select(x => x.Text));
        }
    }
}