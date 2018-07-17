namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class LengthRowTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "LengthRowWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [SetUp]
        public void SetUp()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindButton("reset").Click();
                window.WaitUntilResponsive();
                var saveButton = window.FindButton("save");
                if (saveButton.IsEnabled)
                {
                    saveButton.Click();
                }
            }
        }

        [TestCase("default", "0.0123456", "\u00A0m")]
        [TestCase("propertychanged", "0.0123456", "\u00A0m")]
        [TestCase("readonly", "0.0123456", "\u00A0m")]
        [TestCase("nullable", "", "\u00A0m")]
        [TestCase("explicit cm", "1.23456", "\u00A0cm")]
        public void Initializes(string header, string value, string suffix)
        {
            using (var app = Application.Launch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual(value, window.FindTextBoxRow(header).Value().Text);
                Assert.AreEqual(suffix, window.FindTextBoxRow(header).Suffix().Text);
            }
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("default").Value().Text = "2.3";
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("0.0123456", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("0.0123456", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("1.23456", window.FindTextBoxRow("explicit cm").Value().Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("230", window.FindTextBoxRow("explicit cm").Value().Text);
            }
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("propertychanged").Value().Text = "2.3";
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("230", window.FindTextBoxRow("explicit cm").Value().Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("230", window.FindTextBoxRow("explicit cm").Value().Text);
            }
        }

        [Test]
        public void UpdatesWhenViewModelChanges()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentValueTextBox").Text = "2.3 m";
                window.FindButton("lose focus").Click();
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("2.3", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("230", window.FindTextBoxRow("explicit cm").Value().Text);
            }
        }

        [Test]
        public void WhenUserTypesInGreaterThanMax()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindTextBoxRow("default");

                window.FindTextBox("currentMaxValueTextBox").Text = "2.3 m";
                row.Value().Text = "2.4";

                window.FindButton("lose focus").Click();
                Assert.AreEqual("Please enter a value less than or equal to 2.3.", row.Info().Text);
                Assert.AreEqual("0.0123456\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInGreaterThanMaxCm()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindTextBoxRow("explicit cm");

                window.FindTextBox("currentMaxValueTextBox").Text = "2.3 m";
                row.Value().Text = "240";
                window.FindButton("lose focus").Click();
                Assert.AreEqual("Please enter a value less than or equal to 230.", row.Info().Text);
                Assert.AreEqual("0.0123456\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInLessThanMin()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentMinValueTextBox").Text = "-2.3 m";
                var row = window.FindTextBoxRow("default");
                row.Value().Text = "-2.4";
                window.FindButton("lose focus").Click();
                Assert.AreEqual("Please enter a value greater than or equal to -2.3.", row.Info().Text);
                Assert.AreEqual("0.0123456\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInLessThanMinCm()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentMinValueTextBox").Text = "-2.3 m";
                var row = window.FindTextBoxRow("explicit cm");
                row.Value().Text = "-240";
                window.FindButton("lose focus").Click();
                Assert.AreEqual("Please enter a value greater than or equal to -230.", row.Info().Text);
                Assert.AreEqual("0.0123456\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }
    }
}
