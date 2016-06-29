namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.WindowsAPI;

    public class FocusTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "FocusWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void CyclesFocus()
        {
            var a = this.window.FindSetting("a").Value<TextBox>();
            var b = this.window.FindSetting("b").Value<TextBox>();
            var ro = this.window.FindSetting("readonly").Value<TextBox>();
            a.Focus();
            Assert.True(a.IsFocussed);
            Assert.False(b.IsFocussed);
            Assert.False(ro.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(a.IsFocussed);
            Assert.True(b.IsFocussed);
            Assert.False(ro.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.True(a.IsFocussed);
            Assert.False(b.IsFocussed);
            Assert.False(ro.IsFocussed);
        }
    }
}