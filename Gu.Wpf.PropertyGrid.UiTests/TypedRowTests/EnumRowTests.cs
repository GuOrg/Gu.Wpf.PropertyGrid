namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Linq;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class EnumRowTests
    {
        private const string ExeFileName = "Gu.Wpf.PropertyGrid.Demo.exe";
        private const string WindowName = "EnumRowWindow";

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
                window.FindComboBoxRow("current").Value().Select("CurrentCultureIgnoreCase");
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);

                window.FindComboBoxRow("lostfocus").Value().EditableText = "InvariantCulture";
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);
                window.FindComboBoxRow("lostfocus").Value().Click();
                window.FindButton("lose focus").Click();
                Assert.AreEqual("InvariantCulture", window.FindTextBlock("currentTextBlock").Text);
            }
        }

        [TestCase("current")]
        [TestCase("explicit_type")]
        [TestCase("editable")]
        public void UpdatesWhenPropertyChanged(string header)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindComboBoxRow(header);
                row.Value().Select("CurrentCultureIgnoreCase");
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", row.Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindComboBoxRow("editable").Value().SelectedItem.Text);

                row.Value().Select("Ordinal");
                Assert.AreEqual("Ordinal", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("Ordinal", row.Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("lostfocus").Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("readonly").Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", window.FindComboBoxRow("editable").Value().SelectedItem.Text);
            }
        }

        [Test]
        public void UpdatesWhenPropertyChangedReadOnly()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var row = window.FindComboBoxRow("current");
                var readonlyRow = window.FindComboBoxRow("readonly");

                row.Value().Select("CurrentCultureIgnoreCase");
                Assert.AreEqual("CurrentCultureIgnoreCase", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", row.Value().SelectedItem.Text);
                Assert.AreEqual("CurrentCultureIgnoreCase", readonlyRow.Value().SelectedItem.Text);

                row.Value().Select("Ordinal");
                Assert.AreEqual("Ordinal", window.FindTextBlock("currentTextBlock").Text);
                Assert.AreEqual("Ordinal", row.Value().SelectedItem.Text);
                Assert.AreEqual("Ordinal", readonlyRow.Value().SelectedItem.Text);
            }
        }

        [TestCase("current", false)]
        [TestCase("explicit_type", false)]
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

        [TestCase("current")]
        [TestCase("explicit_type")]
        [TestCase("lostfocus")]
        public void Items(string header)
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var expected = new[]
                               {
                                   "CurrentCulture",
                                   "CurrentCultureIgnoreCase",
                                   "InvariantCulture",
                                   "InvariantCultureIgnoreCase",
                                   "Ordinal",
                                   "OrdinalIgnoreCase"
                               };
                CollectionAssert.AreEqual(expected, window.FindComboBoxRow(header).Value().Items.Select(x => x.Text));
            }
        }
    }
}
