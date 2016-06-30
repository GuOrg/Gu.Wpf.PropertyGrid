namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class ValueStylesTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "ValueStylesWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void UsesStyle()
        {
            Assert.AreEqual("Green", this.window.FindSetting("checkbox").Value<CheckBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("togglebutton").Value<Button>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("enum").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("selector").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("string").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindSetting("double").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindSetting("length").Value<TextBox>().ItemStatus());
        }
    }
}