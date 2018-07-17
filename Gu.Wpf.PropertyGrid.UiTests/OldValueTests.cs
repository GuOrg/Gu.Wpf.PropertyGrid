namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class OldValueTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "OldValueWindow";

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
                var groupBox = window.FindGroupBox("default");
                groupBox.FindTextBoxRow("string").Value().Text = "abc";
                groupBox.FindTextBoxRow("double").Value().Text = "1.2";
                groupBox.FindTextBoxRow("length").Value().Text = "2.3";
                window.FindButton("save").Click();
            }
        }

        [Test]
        public void Default()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("default");
                var stringRow = groupBox.FindTextBoxRow("string");
                stringRow.Value().Text = "g";
                Assert.AreEqual("Old value: abc", stringRow.Info().Text);

                var doubleRow = groupBox.FindTextBoxRow("double");
                doubleRow.Value().Text = "1.23";
                Assert.AreEqual("Old value: 1.2", doubleRow.Info().Text);

                var lengthRow = groupBox.FindTextBoxRow("length");
                lengthRow.Value().Text = "2";
                Assert.AreEqual("Old value: 2.3\u00A0mm", lengthRow.Info().Text);

                window.FindButton("save").Click();
                Assert.AreEqual(string.Empty, stringRow.Info().Text);
                Assert.AreEqual(string.Empty, doubleRow.Info().Text);
                Assert.AreEqual(string.Empty, lengthRow.Info().Text);
            }
        }

        [Test]
        public void Inherits()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("inherits");

                var stringRow = groupBox.FindTextBoxRow("string");
                stringRow.Value().Text = "g";
                var oldStringValue = stringRow.Info();
                Assert.AreEqual("before: abc", oldStringValue.Text);

                var doubleRow = groupBox.FindTextBoxRow("double");
                doubleRow.Value().Text = "1.23";
                var oldDoubleValue = doubleRow.Info();
                Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

                var lengthRow = groupBox.FindTextBoxRow("length");
                lengthRow.Value().Text = "2";
                var oldLengthValue = lengthRow.Info();
                Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

                window.FindButton("save").Click();
                Assert.AreEqual(string.Empty, oldStringValue.Text);
                Assert.AreEqual(string.Empty, oldDoubleValue.Text);
                Assert.AreEqual(string.Empty, oldLengthValue.Text);
            }
        }

        [Test]
        public void Explicit()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("explicit");

                var stringRow = groupBox.FindTextBoxRow("string");
                stringRow.Value().Text = "g";
                var oldStringValue = stringRow.Info();
                Assert.AreEqual("before: abc", oldStringValue.Text);

                var doubleRow = groupBox.FindTextBoxRow("double");
                doubleRow.Value().Text = "1.23";
                var oldDoubleValue = doubleRow.Info();
                Assert.AreEqual("before: 1.2", oldDoubleValue.Text);

                var lengthRow = groupBox.FindTextBoxRow("length");
                lengthRow.Value().Text = "2";
                var oldLengthValue = lengthRow.Info();
                Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

                window.FindButton("save").Click();
                Assert.AreEqual(string.Empty, oldStringValue.Text);
                Assert.AreEqual(string.Empty, oldDoubleValue.Text);
                Assert.AreEqual(string.Empty, oldLengthValue.Text);
            }
        }

        [TestCase("string", "new text")]
        [TestCase("double", "1.23456")]
        [TestCase("length", "1.23456")]
        public void BoundFormatNotUsingValue(string rowName, string text)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("bound");
                groupBox.FindTextBoxRow("old value format").Value().Text = "changed";
                var row = groupBox.FindTextBoxRow(rowName);
                row.Value().Text = text;
                var info = row.Info();
                Assert.AreEqual("changed", info.Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("changed", info.Text);

                window.FindButton("save").Invoke();
                Assert.AreEqual(string.Empty, info.Text);
            }
        }

        [TestCase("string", "g", "before: abc")]
        [TestCase("double", "1.23", "before: 1.2")]
        [TestCase("length", "1.23", "before: 2.3\u00A0mm")]
        public void BoundFormat(string rowName, string text, string expected)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("bound");
                groupBox.FindTextBoxRow("old value format").Value().Text = "before: {0}";

                var row = groupBox.FindTextBoxRow(rowName);
                row.Value().Text = text;
                var info = row.Info();
                Assert.AreEqual(expected, info.Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual(expected, info.Text);

                window.FindButton("save").Click();
                Assert.AreEqual(string.Empty, info.Text);
            }
        }

        [Test]
        public void NoOldValue()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("no old datacontext");

                var stringRow = groupBox.FindTextBoxRow("string");
                stringRow.Value().Text = "g";
                Assert.AreEqual(string.Empty, stringRow.Info().Text);

                var doubleRow = groupBox.FindTextBoxRow("double");
                doubleRow.Value().Text = "1.23";
                Assert.AreEqual(string.Empty, stringRow.Info().Text);
                Assert.AreEqual(string.Empty, doubleRow.Info().Text);

                var lengthRow = groupBox.FindTextBoxRow("length");
                lengthRow.Value().Text = "2";
                Assert.AreEqual(string.Empty, stringRow.Info().Text);
                Assert.AreEqual(string.Empty, doubleRow.Info().Text);
                Assert.AreEqual(string.Empty, lengthRow.Info().Text);
            }
        }
    }
}
