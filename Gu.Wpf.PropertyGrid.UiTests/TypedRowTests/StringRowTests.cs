namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class StringRowTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "StringRowWindow";

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
                window.FindTextBox("currentValueTextBox").Text = string.Empty;
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
                Assert.AreEqual("1", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual(string.Empty, window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual(string.Empty, window.FindTextBoxRow("readonly string").Value().Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("1", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("1", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("1", window.FindTextBoxRow("readonly string").Value().Text);
            }
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("propertychanged").Value().Text = "2";
                Assert.AreEqual("2", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("2", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("2", window.FindTextBoxRow("readonly string").Value().Text);
            }
        }

        [Test]
        public void IsReadonly()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.IsFalse(window.FindTextBoxRow("default").Value().IsReadOnly);
                Assert.IsFalse(window.FindTextBoxRow("propertychanged").Value().IsReadOnly);
                Assert.IsTrue(window.FindTextBoxRow("readonly string").Value().IsReadOnly);
            }
        }
    }
}
