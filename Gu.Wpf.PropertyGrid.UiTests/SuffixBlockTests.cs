namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class SuffixBlockTests
    {
        private const string WindowName = "SuffixBlockWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void SuffixBlockStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("suffixblock style");
                Assert.AreEqual("Green", groupBox.FindTextBlock("abc").ItemStatus);
            }
        }

        [Test]
        public void InheritsTextBlockStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("inherits textblock style");
                Assert.AreEqual("Blue", groupBox.FindTextBlock("abc").ItemStatus);
            }
        }
    }
}