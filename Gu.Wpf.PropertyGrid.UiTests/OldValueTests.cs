namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class OldValueTests
    {
        private const string WindowName = "OldValueWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [SetUp]
        public void SetUp()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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

        [Test]
        public void Bound()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("bound");

                var stringRow = groupBox.FindTextBoxRow("string");
                stringRow.Value().Text = "g";
                var oldStringValue = stringRow.Info();
                Assert.AreEqual("changed", oldStringValue.Text);

                var doubleRow = groupBox.FindTextBoxRow("double");
                doubleRow.Value().Text = "1.23";
                var oldDoubleValue = doubleRow.Info();
                Assert.AreEqual("changed", oldDoubleValue.Text);

                var lengthRow = groupBox.FindTextBoxRow("length");
                lengthRow.Value().Text = "2";
                var oldLengthValue = lengthRow.Info();
                Assert.AreEqual("changed", oldLengthValue.Text);

                groupBox.FindTextBoxRow("old value format").Value().Text = "before: {0}";
                window.FindButton("lose focus").Click();

                Assert.AreEqual("before: abc", oldStringValue.Text);
                Assert.AreEqual("before: 1.2", oldDoubleValue.Text);
                Assert.AreEqual("before: 2.3\u00A0mm", oldLengthValue.Text);

                window.FindButton("save").Click();
                Assert.AreEqual(string.Empty, oldStringValue.Text);
                Assert.AreEqual(string.Empty, oldDoubleValue.Text);
                Assert.AreEqual(string.Empty, oldLengthValue.Text);
            }
        }

        [Test]
        public void NoOldValue()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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