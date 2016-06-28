namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class StyleTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "UsesResourcesStyleForValueWindow";
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
            Assert.AreEqual("Green", this.window.FindSetting("checkbox").Get<CheckBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("togglebutton").Get<Button>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("enum").Get<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("selector").Get<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.window.FindSetting("string").Get<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindSetting("double").Get<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.window.FindSetting("length").Get<TextBox>().ItemStatus());
        }
    }
}