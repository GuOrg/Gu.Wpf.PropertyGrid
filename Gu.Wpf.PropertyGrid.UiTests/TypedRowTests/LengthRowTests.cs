namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class LengthRowTests
    {
        private static readonly string WindowName = "LengthRowWindow";

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
                window.FindTextBox("currentValueTextBox").Text = "1.23 m";
                window.FindTextBox("currentMinValueTextBox").Text = "";
                window.FindTextBox("currentMaxValueTextBox").Text = "";
                window.FindTextBox("currentNullableValueTextBox").Text = "";
                window.FindButton("lose focus").Click();
                if (window.FindButton("save").IsEnabled)
                {
                    window.FindButton("save").Click();
                }
            }
        }

        [Test]
        public void Initializes()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("\u00A0m", window.FindTextBoxRow("default").Suffix().Text);
                Assert.AreEqual("1.23", window.FindTextBoxRow("default").Value().Text);

                Assert.AreEqual("\u00A0m", window.FindTextBoxRow("propertychanged").Suffix().Text);
                Assert.AreEqual("1.23", window.FindTextBoxRow("propertychanged").Value().Text);

                Assert.AreEqual("\u00A0m", window.FindTextBoxRow("readonly").Suffix().Text);
                Assert.AreEqual("1.23", window.FindTextBoxRow("readonly").Value().Text);

                Assert.AreEqual("\u00A0m", window.FindTextBoxRow("readonly").Suffix().Text);
                Assert.AreEqual("", window.FindTextBoxRow("nullable").Value().Text);

                Assert.AreEqual("\u00A0cm", window.FindTextBoxRow("explicit cm").Suffix().Text);
                Assert.AreEqual("123", window.FindTextBoxRow("explicit cm").Value().Text);
            }
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBoxRow("default").Value().Text = "2.3";
                Assert.AreEqual("2.3", window.FindTextBoxRow("default").Value().Text);
                Assert.AreEqual("Old value: 1.23 m", window.FindTextBoxRow("default").Info().Text);
                Assert.AreEqual("1.23", window.FindTextBoxRow("propertychanged").Value().Text);
                Assert.AreEqual("", window.FindTextBoxRow("propertychanged").Info().Text);
                Assert.AreEqual("1.23", window.FindTextBoxRow("readonly").Value().Text);
                Assert.AreEqual("123", window.FindTextBoxRow("explicit cm").Value().Text);

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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var defaultRow = window.FindTextBoxRow("default");

                window.FindTextBox("currentMaxValueTextBox").Text = "2.3 m";
                defaultRow.Value().Text = "2.4";
                Assert.AreEqual("Old value: 1.23 m", defaultRow.Info().Text);
                window.FindButton("lose focus").Click();

                Assert.AreEqual("2,4 > max (2,3)", defaultRow.Info().Text);
                Assert.AreEqual("2.3\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInGreaterThanMaxCm()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentMaxValueTextBox").Text = "2.3 m";
                window.FindTextBoxRow("explicit cm").Value().Text = "240";
                Assert.AreEqual("Old value: 123 m", window.FindTextBoxRow("explicit cm").Info().Text);
                window.FindButton("lose focus").Click();

                Assert.AreEqual("240 > max (230)", window.FindTextBoxRow("default").Info().Text);
                Assert.AreEqual("2.3\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInLessThanMin()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentMinValueTextBox").Text = "-2.3 m";
                window.FindTextBoxRow("default").Value().Text = "-2.4";
                Assert.AreEqual("Old value: 1.23 m", window.FindTextBoxRow("default").Info().Text);
                window.FindButton("lose focus").Click();

                Assert.AreEqual("-2,4 < min (-2,3)", window.FindTextBoxRow("default").Info().Text);
                Assert.AreEqual("2.3\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void WhenUserTypesInLessThanMinCm()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindTextBox("currentMinValueTextBox").Text = "-2.3 m";
                window.FindTextBoxRow("explicit cm").Value().Text = "240";
                Assert.AreEqual("Old value: 1.23 m", window.FindTextBoxRow("default").Info().Text);
                window.FindButton("lose focus").Click();

                Assert.AreEqual("-240 < min (-230)", window.FindTextBoxRow("default").Info().Text);
                Assert.AreEqual("2.3\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }
    }
}