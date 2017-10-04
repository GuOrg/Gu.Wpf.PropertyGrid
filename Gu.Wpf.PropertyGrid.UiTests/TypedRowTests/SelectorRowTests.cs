namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Linq;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class SelectorRowTests
    {
        private const string WindowName = "SelectorRowWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void UpdatesWhenLostFocus()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindComboBoxRow("default").Value().Select("sv-SE");
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
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                window.FindComboBoxRow("default").Value().Select("en-US");
                Assert.AreEqual("en-US", window.FindTextBlock("currentCultureTextBlock").Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("default").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("en-US", window.FindComboBoxRow("editable").Value().SelectedItem.Text);

                window.FindComboBoxRow("default").Value().Select("sv-SE");
                Assert.AreEqual("sv-SE", window.FindTextBlock("currentCultureTextBlock").Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("default").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("sv-SE", window.FindComboBoxRow("editable").Value().SelectedItem.Text);
            }
        }

        [Test]
        public void IsEditable()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.False(window.FindComboBoxRow("default").Value().IsEditable);
                Assert.True(window.FindComboBoxRow("lostfocus").Value().IsEditable);
                Assert.False(window.FindComboBoxRow("readonly").Value().IsEditable);
                Assert.True(window.FindComboBoxRow("editable").Value().IsEditable);
            }
        }

        [Test]
        public void Items()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var expected = new[] { "sv-SE", "en-US" };
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("default").Value().Items.Select(x => x.Text));
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("lostfocus").Value().Items.Select(x => x.Text));
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("readonly").Value().Items.Select(x => x.Text));
            }
        }
    }
}