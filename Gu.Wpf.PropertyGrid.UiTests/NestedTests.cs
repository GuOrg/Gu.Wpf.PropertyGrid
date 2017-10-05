namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class NestedTests
    {
        private const string WindowName = "NestedWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void CyclesFocus()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("nested longer");
                var rootBox = groupBox.FindTextBoxRow("root").Value();
                var shortBox = groupBox.FindTextBoxRow("a").Value();
                var longBox = groupBox.FindTextBoxRow("long header").Value();
                rootBox.Focus();
                Assert.True(rootBox.HasKeyboardFocus);
                Assert.False(shortBox.HasKeyboardFocus);
                Assert.False(longBox.HasKeyboardFocus);

                Keyboard.Type(Key.TAB);
                Assert.False(rootBox.HasKeyboardFocus);
                Assert.True(shortBox.HasKeyboardFocus);
                Assert.False(longBox.HasKeyboardFocus);

                Keyboard.Type(Key.TAB);
                Assert.False(rootBox.HasKeyboardFocus);
                Assert.False(shortBox.HasKeyboardFocus);
                Assert.True(longBox.HasKeyboardFocus);

                Keyboard.Type(Key.TAB);
                window.WaitUntilResponsive();
                Assert.True(rootBox.HasKeyboardFocus);
                Assert.False(shortBox.HasKeyboardFocus);
                Assert.False(longBox.HasKeyboardFocus);
            }
        }

        [TestCase("root")]
        [TestCase("a")]
        [TestCase("long header")]
        public void ColumnWidthsWhenNestedLonger(string name)
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("nested longer");
                var row = groupBox.FindTextBoxRow(name);
                var expected = new[] { 63, 97, 86 };
                CollectionAssert.AreEqual(expected, row.ColumnsWidths());
            }
        }

        [Test]
        public void ColumnWidthsWhenNestedShorter()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("nested shorter");
                var expected = new[] { 21, 38, 56 };
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("root").ColumnsWidths());
                expected[2] = 28;
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("b").ColumnsWidths());
            }
        }
    }
}