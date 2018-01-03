namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class UnitsTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "UnitsWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [SetUp]
        public void SetUp()
        {
            Application.TryWithAttached(
                ExeFileName,
                WindowName,
                app =>
                {
                    var window = app.MainWindow;
                    window.FindTextBox("currentValueTextBox").Text = "0.0123456 m";
                    window.FindButton("lose focus").Click();
                });
        }

        [Test]
        public void ExplicitUnits()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("explicit");
                var metresSetting = groupBox.FindTextBoxRow("length (m)");
                var metresBox = metresSetting.Value();
                var millimetresSetting = groupBox.FindTextBoxRow("length (mm)");
                var millimetresBox = millimetresSetting.Value();

                Assert.AreEqual("0.0123456", metresBox.Text);
                Assert.AreEqual("\u00A0m", metresSetting.Suffix().Text);
                Assert.AreEqual("12.3456", millimetresBox.Text);
                Assert.AreEqual("\u00A0mm", millimetresSetting.Suffix().Text);

                metresBox.Text = "2.4";
                window.FindButton("lose focus").Click();
                Assert.AreEqual("2400", millimetresBox.Text);
            }
        }

        [Test]
        public void UnitFromStyle()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("style");
                var settingControl = groupBox.FindTextBoxRow("length");
                var textBox = settingControl.Value();

                Assert.AreEqual("12.3456", textBox.Text);
                Assert.AreEqual("\u00A0mm", settingControl.Suffix().Text);

                textBox.Text = "2";
                Assert.AreEqual("0.0123456\u00A0m", window.FindTextBox("currentValueTextBox").Text);
                window.FindButton("lose focus").Click();
                Assert.AreEqual("0.002\u00A0m", window.FindTextBox("currentValueTextBox").Text);
            }
        }

        [Test]
        public void BoundUnit()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("bound");
                var settingControl = groupBox.FindTextBoxRow("length");
                var textBox = settingControl.Value();

                Assert.AreEqual("1.23456", textBox.Text);
                Assert.AreEqual("\u00A0cm", settingControl.Suffix().Text);

                groupBox.FindComboBoxRow("selector").Value().Select("m");

                Assert.AreEqual("0.0123456", textBox.Text);
                Assert.AreEqual("\u00A0m", settingControl.Suffix().Text);
            }
        }
    }
}
