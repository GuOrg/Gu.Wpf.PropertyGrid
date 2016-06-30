namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class ColumnsTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "ColumnsWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void Default()
        {
            var groupBox = this.window.GetByText<GroupBox>("default");
            var expected = new[] { 6, 16, 7 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Default_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("default abcd");
            var expected = new[] { 26, 46, 49 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Width_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("Width 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Width_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("Width 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindRow("abcd").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("MinWidth 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("MinWidth 15 20 25 abcd");
            var expected = new[] { 26, 46, 49 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void MaxWidth_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("MaxWidth 15 20 25");
            var expected = new[] { 6, 17, 7 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MaxWidth_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("MaxWidth 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);

            expected = new[] { 15, 46, -1 }; // this looks strange but the textbox gets clipped here.
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}