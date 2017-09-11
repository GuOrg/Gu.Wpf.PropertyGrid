namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Diagnostics.CodeAnalysis;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class SuffixTests
    {
        private static readonly string WindowName = "SuffixWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void Default()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("suffix", window.FindTextBoxRow("default").Suffix().Text);
            }
        }

        [Test]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        public void UsesResourceStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.Inconclusive("not sure how to test this.");
                Assert.AreEqual("implicit blue", window.FindTextBoxRow("implicit suffixblock style").Suffix().ItemStatus);
            }
        }

        [Test]
        public void ExplicitSuffixStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("explicit pink", window.FindTextBoxRow("explicit suffixblock style").Suffix().ItemStatus);
            }
        }

        [Test]
        public void InheritSuffixStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("inherit khaki", window.FindTextBoxRow("inherit suffixblock style").Suffix().ItemStatus);
            }
        }
    }
}