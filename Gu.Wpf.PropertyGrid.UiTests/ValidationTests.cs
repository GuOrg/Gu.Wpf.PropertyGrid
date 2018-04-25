namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class ValidationTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "ValidationErrorWindow";
        private const string LimitedLengthHeader = "Length +-15 mm";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void WhenUserTypesInGreaterThanMax()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var lengthRow = window.FindTextBoxRow(LimitedLengthHeader);
                lengthRow.Value().Text = "15.1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a value between -15 and 15.", lengthRow.Info().Text);
            }
        }

        [Test]
        public void WhenUserTypesInLesserThanMin()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var lengthRow = window.FindTextBoxRow(LimitedLengthHeader);
                lengthRow.Value().Text = "-15.1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a value between -15 and 15.", lengthRow.Info().Text);
            }
        }

        [Test]
        public void WhenUserTypesInNotValidNumber()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var lengthRow = window.FindTextBoxRow(LimitedLengthHeader);
                lengthRow.Value().Text = "-15.a1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a valid number.", lengthRow.Info().Text);
            }
        }

        [Test]
        public void WhenUserTypesInNotValidNumberSpeed()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var unitRow = window.FindTextBoxRow("Speed");
                unitRow.Value().Text = "-15.a1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a valid number.", unitRow.Info().Text);
            }
        }

        [Test]
        public void WhenUserTypesInNotValidNumberDoubleRow()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindTextBoxRow("double");
                row.Value().Text = "-15.a1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a valid number.", row.Info().Text);
            }
        }

        [Test]
        public void WhenUserTypesInNotValidNumberIntRow()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindTextBoxRow("int");
                row.Value().Text = "-15.a1";
                window.FindButton("Lose").Click();
                Assert.AreEqual("Please enter a valid number.", row.Info().Text);
            }
        }
    }
}
