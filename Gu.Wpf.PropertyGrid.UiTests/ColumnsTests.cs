namespace Gu.Wpf.PropertyGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class ColumnsTests
    {
        private static string WindowName = "ColumnsWindow";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(Info.ExeFileName);
        }

        [Test]
        public void Default()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("default");
                var expected = new[] {6, 12, 7};
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
            }
        }

        [Test]
        public void Default_abcd()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("default abcd");
                var expected = new[] {26, 42, 49};
                var actual = groupBox.FindTextBoxRow("a").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
                actual = groupBox.FindTextBoxRow("abcd").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Star_star_star()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("* * *");
                var expected = new[] {33, 33, 33};
                var actual = groupBox.FindTextBoxRow("a").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
                actual = groupBox.FindTextBoxRow("abcd").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Width_15_20_25()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("Width 15 20 25");
                var expected = new[] {15, 20, 25};
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
            }
        }

        [Test]
        public void Width_15_20_25_abcd()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("Width 15 20 25 abcd");
                var expected = new[] {15, 20, 25};
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("abcd").ColumnsWidths());
            }
        }

        [Test]
        public void MinWidth_15_20_25()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("MinWidth 15 20 25");
                var expected = new[] {15, 20, 25};
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
            }
        }

        [Test]
        public void MinWidth_15_20_25_abcd()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("MinWidth 15 20 25 abcd");
                var expected = new[] {26, 42, 49};
                var actual = groupBox.FindTextBoxRow("a").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
                actual = groupBox.FindTextBoxRow("abcd").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void MaxWidth_15_20_25()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("MaxWidth 15 20 25");
                var expected = new[] {6, 13, 7};
                CollectionAssert.AreEqual(expected, groupBox.FindTextBoxRow("a").ColumnsWidths());
            }
        }

        [Test]
        public void MaxWidth_15_20_25_abcd()
        {
            using (var app = Application.AttachOrLaunch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                var groupBox = window.FindGroupBox("MaxWidth 15 20 25 abcd");
                var expected = new[] {15, 20, 25};
                var actual = groupBox.FindTextBoxRow("a").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);

                expected = new[] {15, 42, 3}; // this looks strange but the textbox gets clipped here.
                actual = groupBox.FindTextBoxRow("abcd").ColumnsWidths();
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}