namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class CultureTests
    {
        private const string WindowName = "CultureWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void SvSe()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("sv-se");
                var doubleBox = groupBox.FindTextBoxRow("double").Value();
                var lengthBox = groupBox.FindTextBoxRow("length").Value();

                Assert.AreEqual("0,0000", doubleBox.FormattedText());
                Assert.AreEqual("0,0123", lengthBox.FormattedText());
            }
        }

        [Test]
        public void EnUs()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("en-us");
                var doubleBox = groupBox.FindTextBoxRow("double").Value();
                var lengthBox = groupBox.FindTextBoxRow("length").Value();

                Assert.AreEqual("0.0000", doubleBox.FormattedText());
                Assert.AreEqual("0.0123", lengthBox.FormattedText());
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
                var cultureBox = groupBox.FindComboBoxRow("culture").Value();

                Assert.AreEqual("0,0000", doubleBox.FormattedText());
                Assert.AreEqual("0,0123", lengthBox.FormattedText());

                cultureBox.Select("en-US");
                window.FindButton("lose focus").Click();

                Assert.AreEqual("0.0000", doubleBox.FormattedText());
                Assert.AreEqual("0.0123", lengthBox.FormattedText());
            }
        }
    }
}