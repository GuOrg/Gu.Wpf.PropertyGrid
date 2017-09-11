namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Linq;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class EnumRowTests
    {
        private static readonly string WindowName = "EnumRowWindow";

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
                 window.FindComboBoxRow("current").Value().Select("CurrentCultureIgnoreCase");
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);

                window.FindComboBoxRow("lostfocus").Value().EditableText = "InvariantCulture";
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);

                window.FindButton("lose focus").Click();
                Assert.AreEqual("InvariantCulture", window.FindTextBlock("currentTextBlock").Text);
            }
        }

        [Test]
        public void UpdatesWhenPropertyChanged()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                 window.FindComboBoxRow("current").Value().Select("CurrentCultureIgnoreCase");
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("CurrentCultureIgnoreCase",  window.FindComboBoxRow("current").Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("editable").Value().SelectedItem.Text);

                 window.FindComboBoxRow("current").Value().Select("Ordinal");
                Assert.AreEqual("Ordinal", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("Ordinal",  window.FindComboBoxRow("current").Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("editable").Value().SelectedItem.Text);
            }
        }

        [Test]
        public void IsEditable()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.False( window.FindComboBoxRow("current").Value().IsEditable);
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
                var expected = new[]
                               {
                                   "CurrentCulture", "CurrentCultureIgnoreCase", "InvariantCulture",
                                   "InvariantCultureIgnoreCase", "Ordinal", "OrdinalIgnoreCase"
                               };
                CollectionAssert.AreEqual(expected,  window.FindComboBoxRow("current").Value().Items.Select(x => x.Text));
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("explicit_type").Value().Items.Select(x => x.Text));
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("lostfocus").Value().Items.Select(x => x.Text));
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow("readonly").Value().Items.Select(x => x.Text));
            }
        }
    }
}