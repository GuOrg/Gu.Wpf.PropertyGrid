namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class DecimalDigitsTests
    {
        private static readonly string WindowName = "DecimalDigitsWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void Inherits()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("attached prop");
                var doubleBox = groupBox.FindTextBoxRow("double").Value();
                var lengthBox = groupBox.FindTextBoxRow("length").Value();

                Assert.AreEqual("0.00", doubleBox.FormattedText());
                Assert.AreEqual("12.35", lengthBox.FormattedText());
            }
        }

        [Test]
        public void Explicit()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("explicit");
                var doubleBox = groupBox.FindTextBoxRow("double").Value();
                var lengthBox = groupBox.FindTextBoxRow("length").Value();

                Assert.AreEqual("0.00", doubleBox.FormattedText());
                Assert.AreEqual("12.35", lengthBox.FormattedText());
            }
        }

        [Test]
        public void Bound()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("bound");
                var doubleBox = groupBox.FindTextBoxRow("double").Value();
                var lengthBox = groupBox.FindTextBoxRow("length").Value();
                var digitsBox = groupBox.FindTextBoxRow("digits").Value();

                Assert.AreEqual("0.000", doubleBox.FormattedText());
                Assert.AreEqual("12.346", lengthBox.FormattedText());

                digitsBox.Text = "2";
                window.FindButton("lose focus").Click();

                Assert.AreEqual("0.00", doubleBox.FormattedText());
                Assert.AreEqual("12.35", lengthBox.FormattedText());
            }
        }
    }
}