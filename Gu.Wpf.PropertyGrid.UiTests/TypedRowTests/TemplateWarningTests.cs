namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class TemplateWarningTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "TemplateBindingWindow";

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
                window.FindTextBoxRow("default").Value().Text = "0.0123456";
                window.FindButton("lose focus").Click();
            }
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("default").Value().Text = "1";
                Assert.AreEqual("0.0123456", window.FindTextBoxRow("readonly").Value().Text);
                window.FindButton("lose focus").Click();
                Assert.AreEqual("1", window.FindTextBoxRow("readonly").Value().Text);
            }
        }

        [Test]
        public void UpdatesOnPropChange()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("propertychanged").Value().Text = "12";
                Assert.AreEqual("12", window.FindTextBoxRow("readonly").Value().Text);
            }
        }

        [Test]
        public void UpdatesOnPropChangeStandardStyle()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("propertychangedStandardStyle").Value().Text = "12";
                var lengthRow = window.FindTextBoxRow("propertychangedStandardStyle");
                Assert.AreEqual("Template does not support propertychange", lengthRow.Info().Text);
            }
        }
    }
}
