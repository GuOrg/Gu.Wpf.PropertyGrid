namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;
    using TestStack.White.WindowsAPI;

    public class FocusTests : WindowTests
    {
        protected override string WindowName { get; } = "FocusWindow";

        [Test]
        public void CyclesFocus()
        {
            var a = this.Window.FindRow("a").Value<TextBox>();
            var b = this.Window.FindRow("b").Value<TextBox>();
            var ro = this.Window.FindRow("readonly").Value<TextBox>();
            a.Focus();
            Assert.True(a.IsFocussed);
            Assert.False(b.IsFocussed);
            Assert.False(ro.IsFocussed);

            this.Window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(a.IsFocussed);
            Assert.True(b.IsFocussed);
            Assert.False(ro.IsFocussed);

            this.Window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.True(a.IsFocussed);
            Assert.False(b.IsFocussed);
            Assert.False(ro.IsFocussed);
        }
    }
}