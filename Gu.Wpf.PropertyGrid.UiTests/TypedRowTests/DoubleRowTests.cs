namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class DoubleRowTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "DoubleRowWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [SetUp]
        public void SetUp()
        {
            _ = Application.TryWithAttached(
                ExeFileName,
                WindowName,
                app =>
                {
                    var window = app.MainWindow;
                    window.FindTextBox("currentValueTextBox").Text = "0.0123456";
                    window.FindTextBox("currentNullableValueTextBox").Text = "0.0123456";
                    window.FindButton("lose focus").Click();
                });
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("default").Value().Text = "1";
                Assert.AreEqual("1", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("0.0123456", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("0.0123456", window.FindTextBoxRow("readonly").Value().Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("1", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("1", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("1", window.FindTextBoxRow("readonly").Value().Text);
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
                Assert.AreEqual("2", window.FindTextBoxRow("readonly").Value().Text);
            }
        }

        [Test]
        public void Nullable()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("nullable").Value().Text = string.Empty;
                window.FindButton("lose focus").Click();

                Assert.AreEqual("null", window.FindTextBox("currentNullableValueTextBox").Text);
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
                Assert.IsTrue(window.FindTextBoxRow("readonly").Value().IsReadOnly);
            }
        }
    }
}
