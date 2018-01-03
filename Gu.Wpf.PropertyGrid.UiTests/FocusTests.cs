namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class FocusTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "FocusWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void CyclesFocus()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var a = window.FindTextBoxRow("a").Value();
                var b = window.FindTextBoxRow("b").Value();
                var ro = window.FindTextBoxRow("readonly").Value();
                a.Focus();
                Assert.True(a.HasKeyboardFocus);
                Assert.False(b.HasKeyboardFocus);
                Assert.False(ro.HasKeyboardFocus);

                Keyboard.Type(Key.TAB);
                Assert.False(a.HasKeyboardFocus);
                Assert.True(b.HasKeyboardFocus);
                Assert.False(ro.HasKeyboardFocus);

                Keyboard.Type(Key.TAB);
                window.WaitUntilResponsive();
                Assert.True(a.HasKeyboardFocus);
                Assert.False(b.HasKeyboardFocus);
                Assert.False(ro.HasKeyboardFocus);
            }
        }
    }
}
