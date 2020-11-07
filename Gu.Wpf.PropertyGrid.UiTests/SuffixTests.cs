namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class SuffixTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "SuffixWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void Default()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, WindowName);
            var window = app.MainWindow;
            Assert.AreEqual("suffix", window.FindTextBoxRow("default").Suffix().Text);
        }

        [Test]
        public void ExplicitSuffixTemplate()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, WindowName);
            var window = app.MainWindow;
            Assert.AreEqual("explicit pink", window.FindTextBoxRow("explicit suffix template").Suffix().ItemStatus);
        }

        [Test]
        public void LengthRowGetsDefaultUnit()
        {
            using var app = Application.Launch(ExeFileName, WindowName);
            var window = app.MainWindow;
            Assert.AreEqual("\u00A0m", window.FindTextBoxRow("Default length").Suffix().Text);
        }

        [Test]
        public void LengthRowUpdatesWhenUnitChanges()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, WindowName);
            var window = app.MainWindow;
            var row = window.FindTextBoxRow("Bound length");
            Assert.AreEqual("\u00A0cm", row.Suffix().Text);

            _ = window.FindComboBoxRow("Unit").Value().Select("mm");
            Assert.AreEqual("\u00A0mm", row.Suffix().Text);
        }

        [Test]
        [Ignore("Was [Explicit]")]
        public void InheritSuffixStyle()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, WindowName);
            var window = app.MainWindow;
            var row = window.FindTextBoxRow("Bound speed");
            Assert.AreEqual("\u00A0m/s", row.Suffix().Text);

            _ = window.FindComboBoxRow("SymbolFormat").Value().Select("SignedHatPowers");
            Assert.AreEqual("\u00A0m*s^-1", row.Suffix().Text);
        }
    }
}
