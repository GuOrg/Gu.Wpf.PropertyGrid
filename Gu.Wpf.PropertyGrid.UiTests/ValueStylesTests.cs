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
            Assert.AreEqual("Green", this.window.FindRow("checkbox").Value<CheckBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindRow("togglebutton").Value<Button>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindRow("enum").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindRow("selector").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindRow("string").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindRow("double").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindRow("length").Value<TextBox>().ItemStatus());
        }
    }
}