namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Linq;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class SelectorRowTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "SelectorRowWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                _ = window.FindComboBoxRow("default").Value().Select("sv-SE");
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);

                window.FindComboBoxRow("lostfocus").Value().EditableText = "en-US";
                Assert.AreEqual("sv-SE", window.FindTextBlock("currentCultureTextBlock").Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("en-US", window.FindTextBlock("currentCultureTextBlock").Text);
            }
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                _ = window.FindComboBoxRow("default").Value().Select("en-US");
                Assert.AreEqual("en-US", window.FindTextBlock("currentCultureTextBlock").Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("default").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("editable").Value().SelectedItem.Text);

                _ = window.FindComboBoxRow("default").Value().Select("sv-SE");
                Assert.AreEqual("sv-SE", window.FindTextBlock("currentCultureTextBlock").Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("default").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("editable").Value().SelectedItem.Text);
            }
        }

        [TestCase("default", false)]
        [TestCase("lostfocus", true)]
        [TestCase("readonly", false)]
        [TestCase("editable", true)]
        public void IsEditable(string header, bool expected)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual(expected, window.FindComboBoxRow(header).Value().IsEditable);
            }
        }

        [TestCase("default")]
        [TestCase("lostfocus")]
        [TestCase("editable")]
        public void Items(string header)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var expected = new[] { "sv-SE", "en-US" };
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow(header).Value().Items.Select(x => x.Text));
            }
        }
    }
}
