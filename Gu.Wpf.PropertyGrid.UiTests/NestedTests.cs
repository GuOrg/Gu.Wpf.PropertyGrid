namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.WindowsAPI;

    public class NestedTests
    {
        private Application application;
        private Window window;

        private TextBox defaultBox;
        private TextBox shortBox;
        private TextBox longBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "NestedWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);

            this.defaultBox = this.window.FindSetting("default").Value<TextBox>();
            this.shortBox = this.window.FindSetting("short").Value<TextBox>();
            this.longBox = this.window.FindSetting("long so long").Value<TextBox>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void CyclesFocus()
        {
            this.defaultBox.Focus();
            Assert.True(this.defaultBox.IsFocussed);
            Assert.False(this.shortBox.IsFocussed);
            Assert.False(this.longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(this.defaultBox.IsFocussed);
            Assert.True(this.shortBox.IsFocussed);
            Assert.False(this.longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(this.defaultBox.IsFocussed);
            Assert.False(this.shortBox.IsFocussed);
            Assert.True(this.longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.True(this.defaultBox.IsFocussed);
            Assert.False(this.shortBox.IsFocussed);
            Assert.False(this.longBox.IsFocussed);
        }
    }
}