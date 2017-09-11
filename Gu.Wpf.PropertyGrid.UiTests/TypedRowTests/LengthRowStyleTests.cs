namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class LengthRowStyleTests
    {
        private static readonly string WindowName = "LengthRowStyleWindow";

        [Test]
        public void CorrectValuesAndSuffixes()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var defaultRow = window.FindTextBoxRow("default");
                Assert.AreEqual("\u00A0mm", defaultRow.Suffix().Text);
                Assert.AreEqual("12.3456", defaultRow.Value().Text);

                var cmRow = window.FindTextBoxRow("explicit cm");
                Assert.AreEqual("\u00A0cm", cmRow.Suffix().Text);
                Assert.AreEqual("1.23456", cmRow.Value().Text);
            }
        }
    }
}