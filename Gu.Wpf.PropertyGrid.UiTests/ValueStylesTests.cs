namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class ValueStylesTests
    {
        private static readonly string WindowName = "ValueStylesWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void UsesStyle()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("Green", window.FindCheckBoxRow("checkbox").Value().ItemStatus);
                Assert.AreEqual("Green", window.FindButtonRow("togglebutton").Value().ItemStatus);
                Assert.AreEqual("Green", window.FindComboBoxRow("enum").Value().ItemStatus);
                Assert.AreEqual("Green", window.FindComboBoxRow("selector").Value().ItemStatus);
                Assert.AreEqual("Green", window.FindTextBoxRow("string").Value().ItemStatus);
                Assert.AreEqual("Blue", window.FindTextBoxRow("double").Value().ItemStatus);
                Assert.AreEqual("Blue", window.FindTextBoxRow("length").Value().ItemStatus);
            }
        }
    }
}